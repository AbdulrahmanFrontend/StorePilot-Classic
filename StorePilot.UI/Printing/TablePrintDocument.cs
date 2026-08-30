using StorePilot.UI.Printing.PrintDocumentModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.UI.Printing
{
    /// <summary>
    /// One generic, reusable PrintDocument that renders any <see cref="PrintDocumentModel"/>:
    /// header + reference numbers + info lines + an optional table + totals + an optional
    /// secondary table + a footer note — with correct multi-page pagination.
    ///
    /// This is the ONE printing engine shared by sales invoices, purchase invoices,
    /// sales returns and payment receipts. Each document type only needs a small
    /// "builder" class that fills in a <see cref="PrintDocumentModel"/> (see
    /// StorePilot.UI.Printing.*PrintBuilder) — nothing here is invoice/return/receipt specific.
    ///
    /// Right-to-left layout: columns are laid out right -> left (first column in the
    /// list is drawn on the right, matching Arabic reading order), and all text uses
    /// StringFormatFlags.DirectionRightToLeft so it's right-aligned within its cell.
    /// </summary>
    public class TablePrintDocument : PrintDocument
    {
        private enum Phase { Items, Summary, Extra, Footer, Done }

        private const float RowHeight = 24f;
        private const float CellPadding = 4f;

        private readonly PrintDocumentModel _model;

        private readonly Font _shopNameFont = new Font("Tahoma", 14f, FontStyle.Bold);
        private readonly Font _titleFont = new Font("Tahoma", 12f, FontStyle.Bold);
        private readonly Font _referenceFont = new Font("Tahoma", 11f, FontStyle.Bold);
        private readonly Font _infoFont = new Font("Tahoma", 10f, FontStyle.Regular);
        private readonly Font _tableHeaderFont = new Font("Tahoma", 10f, FontStyle.Bold);
        private readonly Font _tableRowFont = new Font("Tahoma", 10f, FontStyle.Regular);
        private readonly Font _summaryFont = new Font("Tahoma", 10.5f, FontStyle.Bold);
        private readonly Font _footerFont = new Font("Tahoma", 9f, FontStyle.Italic);
        private readonly Font _pageNumberFont = new Font("Tahoma", 8f, FontStyle.Regular);

        private readonly StringFormat _rtlNear = new StringFormat(StringFormatFlags.DirectionRightToLeft)
        { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter };

        private readonly StringFormat _rtlFar = new StringFormat(StringFormatFlags.DirectionRightToLeft)
        { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };

        private readonly StringFormat _rtlCenter = new StringFormat(StringFormatFlags.DirectionRightToLeft)
        { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        // Pagination state — reset in OnBeginPrint, advanced across OnPrintPage calls.
        private Phase _phase;
        private int _itemRowIndex;
        private int _extraRowIndex;
        private int _pageNumber;

        public TablePrintDocument(PrintDocumentModel model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));

            DefaultPageSettings.Margins = new Margins(50, 50, 50, 50); // 1/100 inch
            DefaultPageSettings.Landscape = false;
        }

        protected override void OnBeginPrint(System.Drawing.Printing.PrintEventArgs e)
        {
            base.OnBeginPrint(e);
            _phase = (_model.Columns == null || _model.Columns.Count == 0) ? Phase.Summary : Phase.Items;
            _itemRowIndex = 0;
            _extraRowIndex = 0;
            _pageNumber = 1;
        }

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            var g = e.Graphics;
            var mb = e.MarginBounds;
            float y = mb.Top;

            y = DrawPageTopHeader(g, mb, y);

            if (_phase == Phase.Items)
            {
                if (_itemRowIndex == 0)
                    y = DrawInfoBlock(g, mb.Left, mb.Right, y);

                y = DrawTableSection(g, _model.Columns, _model.Rows, ref _itemRowIndex,
                                      mb.Left, mb.Right, y, mb.Bottom, out bool pageFull);
                if (pageFull)
                {
                    e.HasMorePages = true;
                    _pageNumber++;
                    return;
                }
                _phase = Phase.Summary;
            }

            if (_phase == Phase.Summary)
            {
                float estimatedHeight = (_model.SummaryLines?.Count ?? 0) * RowHeight + 10f;
                if (y + estimatedHeight > mb.Bottom)
                {
                    e.HasMorePages = true;
                    _pageNumber++;
                    return;
                }
                y = DrawSummaryLines(g, mb.Left, mb.Right, y);
                _phase = (_model.ExtraSection != null && _model.ExtraSection.Rows.Count > 0) ? Phase.Extra : Phase.Footer;
            }

            if (_phase == Phase.Extra)
            {
                if (_extraRowIndex == 0)
                {
                    y += 10f;
                    var titleRect = new RectangleF(mb.Left, y, mb.Width, RowHeight);
                    g.DrawString(_model.ExtraSection.Title, _tableHeaderFont, Brushes.Black, titleRect, _rtlNear);
                    y += RowHeight;
                }

                y = DrawTableSection(g, _model.ExtraSection.Columns, _model.ExtraSection.Rows, ref _extraRowIndex,
                                      mb.Left, mb.Right, y, mb.Bottom, out bool pageFull);
                if (pageFull)
                {
                    e.HasMorePages = true;
                    _pageNumber++;
                    return;
                }
                _phase = Phase.Footer;
            }

            if (_phase == Phase.Footer)
            {
                if (!string.IsNullOrWhiteSpace(_model.FooterNote))
                {
                    var footerRect = new RectangleF(mb.Left, mb.Bottom - 30f, mb.Width, 24f);
                    g.DrawString(_model.FooterNote, _footerFont, Brushes.Black, footerRect, _rtlCenter);
                }
                _phase = Phase.Done;
                e.HasMorePages = false;
            }
        }

        // ---------------------------------------------------------------
        // Drawing helpers
        // ---------------------------------------------------------------

        private float DrawPageTopHeader(Graphics g, Rectangle mb, float y)
        {
            var shopRect = new RectangleF(mb.Left, y, mb.Width, 26f);
            g.DrawString(_model.ShopName ?? string.Empty, _shopNameFont, Brushes.Black, shopRect, _rtlCenter);
            y += 30f;

            var titleRect = new RectangleF(mb.Left, y, mb.Width, 22f);
            g.DrawString(_model.DocumentTitle ?? string.Empty, _titleFont, Brushes.Black, titleRect, _rtlCenter);
            y += 26f;

            // Reference numbers, one under another, right-aligned — printed on EVERY page
            // so a page separated from the rest of the invoice can still be identified.
            foreach (var (label, value) in _model.ReferenceLines ?? Enumerable.Empty<(string, string)>())
            {
                var refRect = new RectangleF(mb.Left, y, mb.Width, 18f);
                g.DrawString($"{label}: {value}", _referenceFont, Brushes.Black, refRect, _rtlFar);
                y += 20f;
            }

            // Page number, top-left corner (LTR-neutral position)
            g.DrawString($"صفحة {_pageNumber}", _pageNumberFont, Brushes.Gray,
                new RectangleF(mb.Left, mb.Top, 100f, 16f), _rtlNear);

            y += 4f;
            g.DrawLine(Pens.Black, mb.Left, y, mb.Right, y);
            y += 8f;
            return y;
        }

        private float DrawInfoBlock(Graphics g, float left, float right, float y)
        {
            foreach (var (label, value) in _model.HeaderInfoLines ?? Enumerable.Empty<(string, string)>())
            {
                var rect = new RectangleF(left, y, right - left, 18f);
                g.DrawString($"{label}: {value}", _infoFont, Brushes.Black, rect, _rtlFar);
                y += 20f;
            }
            y += 6f;
            return y;
        }

        private (float X, float Width)[] ComputeColumnGeometry(List<PrintColumn> columns, float left, float right)
        {
            var geometry = new (float, float)[columns.Count];
            float totalPercent = columns.Sum(c => c.WidthPercent);
            if (totalPercent <= 0) totalPercent = 100f;
            float availableWidth = right - left;
            float xRight = right;
            for (int i = 0; i < columns.Count; i++)
            {
                float w = availableWidth * (columns[i].WidthPercent / totalPercent);
                float xLeft = xRight - w;
                geometry[i] = (xLeft, w);
                xRight = xLeft;
            }
            return geometry;
        }

        /// <summary>
        /// Draws a table's header row once, then as many data rows as fit before
        /// <paramref name="bottomLimit"/>. Advances <paramref name="rowIndex"/> as it goes
        /// so subsequent pages resume exactly where the previous page stopped.
        /// </summary>
        private float DrawTableSection(Graphics g, List<PrintColumn> columns, List<object> rows,
                                        ref int rowIndex, float left, float right, float y,
                                        float bottomLimit, out bool pageFull)
        {
            pageFull = false;
            if (columns == null || columns.Count == 0)
                return y;

            var geometry = ComputeColumnGeometry(columns, left, right);

            // Header row (shaded background)
            using (var headerBrush = new SolidBrush(Color.FromArgb(230, 230, 230)))
                g.FillRectangle(headerBrush, left, y, right - left, RowHeight);

            for (int i = 0; i < columns.Count; i++)
            {
                var (x, w) = geometry[i];
                var rect = new RectangleF(x + CellPadding, y, w - CellPadding * 2, RowHeight);
                g.DrawString(columns[i].Header, _tableHeaderFont, Brushes.Black, rect, _rtlNear);
            }
            y += RowHeight;
            g.DrawLine(Pens.Black, left, y, right, y);

            // Data rows
            while (rowIndex < rows.Count)
            {
                if (y + RowHeight > bottomLimit)
                {
                    pageFull = true;
                    return y;
                }

                var rowData = rows[rowIndex];
                for (int i = 0; i < columns.Count; i++)
                {
                    var (x, w) = geometry[i];
                    var rect = new RectangleF(x + CellPadding, y, w - CellPadding * 2, RowHeight);
                    string text = columns[i].ValueSelector?.Invoke(rowData) ?? string.Empty;
                    g.DrawString(text, _tableRowFont, Brushes.Black, rect, _rtlNear);
                }
                y += RowHeight;
                g.DrawLine(Pens.LightGray, left, y, right, y);
                rowIndex++;
            }

            return y;
        }

        private float DrawSummaryLines(Graphics g, float left, float right, float y)
        {
            y += 6f;
            foreach (var (label, value) in _model.SummaryLines ?? Enumerable.Empty<(string, string)>())
            {
                var rect = new RectangleF(left, y, right - left, RowHeight);
                g.DrawString($"{label}:  {value}", _summaryFont, Brushes.Black, rect, _rtlFar);
                y += RowHeight;
            }
            return y;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _shopNameFont.Dispose();
                _titleFont.Dispose();
                _referenceFont.Dispose();
                _infoFont.Dispose();
                _tableHeaderFont.Dispose();
                _tableRowFont.Dispose();
                _summaryFont.Dispose();
                _footerFont.Dispose();
                _pageNumberFont.Dispose();
                _rtlNear.Dispose();
                _rtlFar.Dispose();
                _rtlCenter.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

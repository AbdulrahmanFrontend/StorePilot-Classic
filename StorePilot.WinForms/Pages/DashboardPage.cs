using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Krypton.Toolkit;
using StorePilot.WinForms.Foundation.FakeData;
using StorePilot.WinForms.Theme;
using StorePilot.WinForms.UI.Controls;

namespace StorePilot.WinForms.Pages
{
    public sealed class DashboardPage : UserControl
    {
        private readonly FakeDataStore _data = FakeDataStore.Instance;
        private readonly TableLayoutPanel _cards;
        private readonly KryptonLabel _salesValue;
        private readonly KryptonDataGridView _recentGrid;
        private readonly KryptonDataGridView _lowStockGrid;

        public DashboardPage()
        {
            Dock = DockStyle.Fill;
            BackColor = AppTheme.Background;
            RightToLeft = RightToLeft.Yes;

            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(24),
                RowCount = 4,
                ColumnCount = 1
            };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 45));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 115));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 38));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            var title = UiFactory.CreateTitle("الرئيسية");
            root.Controls.Add(title, 0, 0);

            _cards = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 1
            };
            for (int i = 0; i < 4; i++)
                _cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));

            var salesCard = new SummaryCard("مبيعات اليوم", FormatMoney(_data.TodaySales));
            _salesValue = FindValueLabel(salesCard);
            _cards.Controls.Add(salesCard, 0, 0);
            _cards.Controls.Add(new SummaryCard("مستحقات العملاء", FormatMoney(_data.CustomerBalances)), 1, 0);
            _cards.Controls.Add(new SummaryCard("مستحقات الموردين", FormatMoney(_data.SupplierBalances)), 2, 0);
            _cards.Controls.Add(new SummaryCard("منخفض المخزون", _data.LowStockCount.ToString()), 3, 0);
            root.Controls.Add(_cards, 0, 1);

            var recentTitle = UiFactory.CreateSubtitle("آخر فواتير البيع");
            recentTitle.StateCommon.ShortText.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            root.Controls.Add(recentTitle, 0, 2);

            var bottom = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62));
            bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38));

            _recentGrid = CreateGrid();
            _recentGrid.DataSource = _data.RecentSales.Select(x => new
            {
                رقم_الفاتورة = x.Number,
                التاريخ = x.Date.ToString("dd/MM/yyyy HH:mm"),
                العميل = x.Party,
                الإجمالي = x.Total.ToString("N2"),
                الحالة = x.Status
            }).ToList();

            _lowStockGrid = CreateGrid();
            _lowStockGrid.DataSource = _data.Products
                .Where(x => x.Active && x.Quantity <= x.MinQuantity)
                .Select(x => new
                {
                    الكود = x.Code,
                    المنتج = x.Name,
                    المخزون = x.Quantity.ToString("N2"),
                    الحد_الأدنى = x.MinQuantity.ToString("N2")
                }).ToList();

            var recentPanel = WrapGrid(_recentGrid, "آخر الفواتير");
            var lowPanel = WrapGrid(_lowStockGrid, "تنبيهات المخزون");

            bottom.Controls.Add(recentPanel, 0, 0);
            bottom.Controls.Add(lowPanel, 1, 0);
            root.Controls.Add(bottom, 0, 3);

            Controls.Add(root);
        }

        private static KryptonLabel FindValueLabel(SummaryCard card)
        {
            return card.Controls.OfType<KryptonLabel>()
                .OrderByDescending(x => x.Font.Size)
                .First();
        }

        private static string FormatMoney(decimal value) => value.ToString("N2") + " ج.م";

        private static KryptonDataGridView CreateGrid()
        {
            var grid = new KryptonDataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoGenerateColumns = true,
                RowHeadersVisible = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            return grid;
        }

        private static KryptonPanel WrapGrid(Control grid, string title)
        {
            var panel = new KryptonPanel { Dock = DockStyle.Fill, Margin = new Padding(6) };
            panel.StateCommon.Color1 = AppTheme.Surface;

            var label = UiFactory.CreateSubtitle(title);
            label.Location = new Point(12, 10);
            label.StateCommon.ShortText.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);

            grid.Location = new Point(8, 42);
            grid.Size = new Size(300, 300);
            grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            panel.Controls.Add(grid);
            panel.Controls.Add(label);
            return panel;
        }

        public void ApplyTheme()
        {
            BackColor = AppTheme.Background;
            foreach (Control control in _cards.Controls)
                if (control is SummaryCard card)
                    card.ApplyTheme();
        }
    }
}

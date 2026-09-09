using Krypton.Toolkit;
using StorePilot.WinForms.Foundation.FakeData;
using StorePilot.WinForms.Theme;
using StorePilot.WinForms.UI.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Pages
{
    public class ReferenceDataPage : UserControl
    {
        private readonly string _title;
        private readonly System.Collections.Generic.List<FakeReferenceItem> _items;
        private readonly KryptonDataGridView _grid;

        public ReferenceDataPage(string title, System.Collections.Generic.List<FakeReferenceItem> items)
        {
            _title = title;
            _items = items;
            Dock = DockStyle.Fill;
            BackColor = AppTheme.Background;
            RightToLeft = RightToLeft.Yes;

            var root = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(24), RowCount = 2, ColumnCount = 1 };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            var header = new KryptonPanel { Dock = DockStyle.Fill };
            var titleLabel = UiFactory.CreateTitle(_title);
            titleLabel.Location = new Point(0, 0);
            header.Controls.Add(titleLabel);

            _grid = new KryptonDataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            _grid.DataSource = _items.Select(x => new { x.Id, الاسم = x.Name, الحالة = x.Active ? "نشط" : "موقوف" }).ToList();
            if (_grid.Columns["Id"] != null) _grid.Columns["Id"]?.Visible = false;

            root.Controls.Add(header, 0, 0);
            root.Controls.Add(_grid, 0, 1);
            Controls.Add(root);
        }
    }
}

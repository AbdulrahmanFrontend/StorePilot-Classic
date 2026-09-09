using Krypton.Toolkit;
using StorePilot.WinForms.Forms;
using StorePilot.WinForms.Foundation.FakeData;
using StorePilot.WinForms.Theme;
using StorePilot.WinForms.UI.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Pages
{
    public sealed class ProductsPage : UserControl
    {
        private readonly FakeDataStore _data = FakeDataStore.Instance;
        private readonly KryptonDataGridView _grid;
        private readonly KryptonTextBox _search;

        public ProductsPage()
        {
            Dock = DockStyle.Fill;
            BackColor = AppTheme.Background;
            RightToLeft = RightToLeft.Yes;

            var root = CreateRoot();
            var header = CreateHeader("المنتجات", "إدارة الأصناف والأسعار والمخزون");

            var add = UiFactory.CreatePrimaryButton("+ منتج");
            add.Dock = DockStyle.Right;
            add.Click += (_, _) => AddProduct();

            header.Controls.Add(add);
            root.Controls.Add(header, 0, 0);

            var filters = new FlowLayoutPanel { Dock = DockStyle.Fill, Height = 48 };
            _search = new KryptonTextBox { Width = 300 };
            filters.Controls.Add(_search);

            var group = new KryptonComboBox { Width = 150 };
            group.Items.Add("كل المجموعات");
            group.Items.AddRange(_data.Groups.Select(x => x.Name).ToArray());
            group.SelectedIndex = 0;
            group.SelectedIndexChanged += (_, _) => RefreshGrid(group);
            _search.TextChanged += (_, _) => RefreshGrid(group);
            filters.Controls.Add(group);

            root.Controls.Add(filters, 0, 1);

            _grid = CreateGrid();
            root.Controls.Add(_grid, 0, 2);

            Controls.Add(root);
            //var selectedGroup = group.SelectedItem?.ToString();
            RefreshGrid(group);
        }

        void RefreshGrid(KryptonComboBox group)
        {
            var q = _search.Text.Trim();
            var selectedGroup = group.SelectedItem?.ToString();

            var data = _data.Products
                .Where(x => string.IsNullOrWhiteSpace(q) ||
                            x.Name.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                            x.Code.Contains(q, StringComparison.OrdinalIgnoreCase))
                .Where(x => selectedGroup == "كل المجموعات" || x.Group == selectedGroup)
                .Select(x => new
                {
                    x.Id,
                    الكود = x.Code,
                    المنتج = x.Name,
                    المجموعة = x.Group,
                    الوحدة = x.Unit,
                    المخزون = x.Quantity.ToString("N2"),
                    الحد_الأدنى = x.MinQuantity.ToString("N2"),
                    سعر_البيع = x.SalePrice.ToString("N2"),
                    الحالة = x.Active ? "نشط" : "موقوف"
                }).ToList();

            _grid?.DataSource = data;
            if (_grid?.Columns["Id"] != null)
                _grid.Columns["Id"]?.Visible = false;
        }

        private void AddProduct()
        {
            using var dialog = new ProductDialog(_data);
            if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
                Refresh();
        }

        private new void Refresh()
        {
            // Recreate the bound view without rebuilding the page.
            foreach (Control c in Controls)
                if (c is TableLayoutPanel root)
                    foreach (Control child in root.Controls)
                        if (child is KryptonDataGridView grid)
                            grid.DataSource = _data.Products.Select(x => new
                            {
                                x.Id,
                                الكود = x.Code,
                                المنتج = x.Name,
                                المجموعة = x.Group,
                                الوحدة = x.Unit,
                                المخزون = x.Quantity.ToString("N2"),
                                سعر_البيع = x.SalePrice.ToString("N2"),
                                الحالة = x.Active ? "نشط" : "موقوف"
                            }).ToList();
        }

        private static TableLayoutPanel CreateRoot()
        {
            var root = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(24), RowCount = 3, ColumnCount = 1 };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 55));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            return root;
        }

        private static KryptonPanel CreateHeader(string title, string subtitle)
        {
            var panel = new KryptonPanel { Dock = DockStyle.Fill };
            var t = UiFactory.CreateTitle(title);
            t.Location = new Point(0, 0);
            var s = UiFactory.CreateSubtitle(subtitle);
            s.Location = new Point(2, 34);
            panel.Controls.Add(t);
            panel.Controls.Add(s);
            return panel;
        }

        private static KryptonDataGridView CreateGrid()
        {
            var grid = new KryptonDataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            return grid;
        }
    }
}

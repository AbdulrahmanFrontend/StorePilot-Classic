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
    public class PartyPage : UserControl
    {
        private readonly bool _customer;
        private readonly FakeDataStore _data = FakeDataStore.Instance;
        private readonly KryptonDataGridView _grid;

        public PartyPage(bool customer)
        {
            _customer = customer;
            Dock = DockStyle.Fill;
            BackColor = AppTheme.Background;
            RightToLeft = RightToLeft.Yes;

            var root = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(24), RowCount = 2, ColumnCount = 1 };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            var header = new KryptonPanel { Dock = DockStyle.Fill };
            var title = UiFactory.CreateTitle(customer ? "العملاء" : "الموردون");
            title.Location = new Point(0, 0);
            var add = UiFactory.CreatePrimaryButton(customer ? "+ عميل" : "+ مورد");
            add.Dock = DockStyle.Right;
            add.Click += (_, _) => AddParty();
            header.Controls.Add(add);
            header.Controls.Add(title);

            _grid = new KryptonDataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            root.Controls.Add(header, 0, 0);
            root.Controls.Add(_grid, 0, 1);
            Controls.Add(root);
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            var source = _customer ? _data.Customers : _data.Suppliers;
            _grid.DataSource = source.Select(x => new
            {
                x.Id,
                الاسم = x.Name,
                الهاتف = x.Phone,
                العنوان = x.Address,
                الإجمالي = x.Total.ToString("N2"),
                المدفوع = x.Paid.ToString("N2"),
                الرصيد = x.Balance.ToString("N2"),
                الحالة = x.Active ? "نشط" : "موقوف"
            }).ToList();

            if (_grid.Columns["Id"] != null)
                _grid.Columns["Id"]?.Visible = false;
        }

        private void AddParty()
        {
            using var dialog = new PartyDialog(_customer);
            if (dialog.ShowDialog(FindForm()) != DialogResult.OK)
                return;

            var party = new FakeParty
            {
                Name = dialog.PartyName,
                Phone = dialog.Phone,
                Address = dialog.Address
            };

            if (_customer)
                _data.AddCustomer(party);
            else
                _data.AddSupplier(party);

            RefreshGrid();
        }
    }
}

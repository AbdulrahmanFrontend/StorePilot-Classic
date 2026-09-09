using Krypton.Toolkit;
using StorePilot.WinForms.Foundation.FakeData;
using StorePilot.WinForms.Theme;
using StorePilot.WinForms.UI.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace StorePilot.WinForms.Forms
{
    internal sealed class ProductDialog : KryptonForm
    {
        private readonly FakeDataStore _data;
        private readonly KryptonTextBox _name = new();
        private readonly KryptonTextBox _code = new();
        private readonly KryptonNumericUpDown _quantity = new();
        private readonly KryptonNumericUpDown _sale = new();
        public ProductDialog(FakeDataStore data)
        {
            _data = data;
            Text = "إضافة منتج";
            ClientSize = new Size(440, 390);
            AppTheme.ApplyBase(this);
            Build();
        }

        private void Build()
        {
            var panel = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(24), ColumnCount = 2, RowCount = 6 };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            Add(panel, "الكود", _code, 0);
            Add(panel, "اسم المنتج", _name, 1);
            Add(panel, "الكمية", _quantity, 2);
            Add(panel, "سعر البيع", _sale, 3);

            var save = UiFactory.CreatePrimaryButton("حفظ");
            save.Click += (_, _) =>
            {
                if (string.IsNullOrWhiteSpace(_name.Text))
                {
                    KryptonMessageBox.Show(this, "أدخل اسم المنتج.", "تنبيه");
                    return;
                }
                _data.AddProduct(new FakeProduct
                {
                    Code = _code.Text.Trim(),
                    Name = _name.Text.Trim(),
                    Group = "مواسير",
                    Unit = "قطعة",
                    Quantity = _quantity.Value,
                    SalePrice = _sale.Value,
                    PurchasePrice = 0,
                    MinQuantity = 0
                });
                DialogResult = DialogResult.OK;
            };
            panel.Controls.Add(save, 1, 5);
            Controls.Add(panel);
        }

        private static void Add(TableLayoutPanel panel, string label, Control control, int row)
        {
            panel.Controls.Add(new KryptonLabel { Text = label, Dock = DockStyle.Fill }, 0, row);
            control.Dock = DockStyle.Fill;
            panel.Controls.Add(control, 1, row);
        }
    }
}

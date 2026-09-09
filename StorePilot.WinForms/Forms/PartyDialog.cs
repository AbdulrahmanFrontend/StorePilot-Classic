using Krypton.Toolkit;
using StorePilot.WinForms.Theme;
using StorePilot.WinForms.UI.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace StorePilot.WinForms.Forms
{
    internal sealed class PartyDialog : KryptonForm
    {
        private readonly KryptonTextBox _name = new();
        private readonly KryptonTextBox _phone = new();
        private readonly KryptonTextBox _address = new();

        public string PartyName => _name.Text.Trim();
        public string Phone => _phone.Text.Trim();
        public string Address => _address.Text.Trim();

        public PartyDialog(bool customer)
        {
            Text = customer ? "إضافة عميل" : "إضافة مورد";
            ClientSize = new Size(440, 300);
            AppTheme.ApplyBase(this);

            var panel = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(24), ColumnCount = 2, RowCount = 4 };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            Add(panel, "الاسم", _name, 0);
            Add(panel, "الهاتف", _phone, 1);
            Add(panel, "العنوان", _address, 2);

            var save = UiFactory.CreatePrimaryButton("حفظ");
            save.Click += (_, _) =>
            {
                if (string.IsNullOrWhiteSpace(_name.Text))
                {
                    KryptonMessageBox.Show(this, "أدخل الاسم.", "تنبيه");
                    return;
                }
                DialogResult = DialogResult.OK;
            };
            panel.Controls.Add(save, 1, 3);
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

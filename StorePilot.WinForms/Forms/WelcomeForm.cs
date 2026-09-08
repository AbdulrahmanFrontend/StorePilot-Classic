using System;
using System.Drawing;
using System.Windows.Forms;
using Krypton.Toolkit;
using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.Forms
{
    public partial class WelcomeForm : KryptonForm
    {
        private readonly AppBrandSettingsStore _settingsStore;

        public WelcomeForm(AppBrandSettingsStore settingsStore)
        {
            InitializeComponent();

            _settingsStore =
                settingsStore ?? throw new ArgumentNullException(nameof(settingsStore));

            AppTheme.ApplyBase(this);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            using (var setup = new ShopSetupForm(_settingsStore))
            {
                if (setup.ShowDialog(this) == DialogResult.OK)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

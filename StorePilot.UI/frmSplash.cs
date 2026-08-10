using DevToolkit.BaseWinForms.Controls.UserControls;
using DevToolkit.BaseWinForms.Forms;
using DevToolkit.BaseWinForms.Theming;
using DevToolkit.Infrastructure.Database;
using DevToolkit.Infrastructure.Startup;
using StorePilot.UI.Global.Classes;
using DevToolkit.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorePilot.UI
{
    public partial class frmSplash : frmBase
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        protected override void ApplyTheme()
        {
            this.BackColor = Theme.Background;
            this.ForeColor = Theme.Text;
            this.SplashScreen.TitleColor = Theme.Primary;
            this.SplashScreen.ForeColor = Theme.TextSecondary;
        }

        private async void SplashScreen_SplashCompleted(
            object sender, 
            EventArgs e)
        {
            this.Hide();

            frmMain frm = new frmMain();

            await Task.Delay(500); // Simulate some loading time

            frm.OnClose += s => this.Close();

            frm.Show();
        }

        private async void frmSplash_Load(object sender, EventArgs e)
        {
            await Task.Run(() => StartupManager.Initialize(new StartupOptions
            {
                ApplicationName = "StorePilot",
                CompanyName = "DevToolkit",
                EnableFileLogging = true,
            },
            new DatabaseOptions
            {
                CreateIfNotExists = true,
                RunScripts = true,
                DatabaseName = "StorePilotDB",
                Provider = DbProviderFactory.DbProvider.SQLite
            }));
        }
    }
}

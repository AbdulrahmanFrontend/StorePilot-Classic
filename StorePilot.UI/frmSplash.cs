using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevToolkit.BaseWinForms.Controls.UserControls;

namespace StorePilot.UI
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private async void SplashScreen_SplashCompleted(
            object sender, 
            ucSplashScreen.SplashCompletedEventArgs e)
        {
            this.Hide();

            frmMain frm = new frmMain();

            await Task.Delay(500); // Simulate some loading time

            frm.OnClose += s => this.Close();

            frm.Show();
        }
    }
}

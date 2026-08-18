using DevToolkit.BaseWinForms.Controls.UserControls;
using DevToolkit.BaseWinForms.Forms;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.BaseWinForms.Models;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using DevToolkit.Data.Core;
using DevToolkit.Infrastructure.Database;
using DevToolkit.Infrastructure.FileSystem;
using DevToolkit.Infrastructure.Startup;
using StorePilot.UI.CashTransactions;
using StorePilot.UI.Customers;
using StorePilot.UI.Global;
using StorePilot.UI.Global.Classes;
using StorePilot.UI.Products;
using StorePilot.UI.Properties;
using StorePilot.UI.Purchases;
using StorePilot.UI.Sales;
using StorePilot.UI.Settings;
using StorePilot.UI.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorePilot.UI
{
    public partial class frmMain : frmMainLayout
    {
        private UserControl _Screen;

        public frmMain()
        {
            InitializeComponent();
        }

        protected override void ApplyTheme()
        {
            this.BackColor = Theme.Border;
            this.Headerbar.BackColor = Theme.Primary;
            this.Headerbar.ForeColor = Color.White;
            this.Headerbar.ButtonColor = Theme.TextSecondary;
            this.Sidebar.BackColor = Theme.Primary;
            this.Sidebar.ForeColor = Color.White;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _InitializeSidebar();
            _InitializeHeaderbar();
        }

        private void _InitializeSidebar()
        {
            Sidebar.Logo = Resources.sink;
            Sidebar.Width = 150;
            Sidebar.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            Sidebar.Dock = DockStyle.Left;

            Sidebar.ButtonsInfo = new List<NavigationItem>()
            {
                new NavigationItem
                {
                    Title = "الرئيسية",
                    Icon = Resources.home,
                    Index = 0,
                },
                new NavigationItem
                {
                    Title = "الأصناف",
                    Icon = Resources.product,
                    Index = 1,
                },
                new NavigationItem
                {
                    Title = "المبيعات",
                    Icon = Resources.sales,
                    Index = 2,
                },
                new NavigationItem
                {
                    Title = "العملاء",
                    Icon = Resources.customer,
                    Index = 3,
                },
                new NavigationItem
                {
                    Title = "المشتريات",
                    Icon = Resources.purchases,
                    Index = 4,
                },
                new NavigationItem
                {
                    Title = "الموردون",
                    Icon = Resources.supplier,
                    Index = 5,
                },
                new NavigationItem
                {
                    Title = "الصندوق",
                    Icon = Resources.cash,
                    Index = 6,
                },
                //new NavigationItem
                //{
                //    Title = "التقارير",
                //    Icon = Resources.reports,
                //    Index = 7,
                //},
                new NavigationItem
                {
                    Title = "الإعدادات",
                    Icon = Resources.settings,
                    Index = 8,
                },
            };

            Sidebar.SelectButton(0);
            _ShowScreen(new ucDashboardScreen());

            Sidebar.ScreenSelected += SelectScreen;
        }

        private void SelectScreen(
            object sender,
            ucSidebar.ScreenSelectedEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    if (_Screen is ucDashboardScreen)
                        return;
                    _ShowScreen(new ucDashboardScreen());
                    break;

                case 1:
                    if (_Screen is ucProductsScreen)
                        return;
                    _ShowScreen(new ucProductsScreen());
                    break;

                case 2:
                    if (_Screen is ucSalesScreen)
                        return;
                    _ShowScreen(new ucSalesScreen());
                    break;

                case 3:
                    if (_Screen is ucCustomersScreen)
                        return;
                    _ShowScreen(new ucCustomersScreen());
                    break;

                case 4:
                    if (_Screen is ucPurchasesScreen)
                        return;
                    _ShowScreen(new ucPurchasesScreen());
                    break;

                case 5:
                    if (_Screen is ucSuppliersScreen)
                        return;
                    _ShowScreen(new ucSuppliersScreen());
                    break;

                case 6:
                    if (_Screen is ucCashTransactionsScreen)
                        return;
                    _ShowScreen(new ucCashTransactionsScreen());
                    break;

                //case 7:
                //    if (_Screen is ucReportsScreen)
                //        return;
                //    _ShowScreen(new ucReportsScreen());
                //    break;

                case 8:
                    if (_Screen is ucSettingsScreen)
                        return;
                    _ShowScreen(new ucSettingsScreen());
                    break;

                default:
                    _ShowScreen();
                    break;
            }
        }

        private void _ShowScreen(UserControl screen = null)
        {
            _Screen = screen;
            ScreenManager.ShowScreen(pnlContent, _Screen);
        }

        private void _InitializeHeaderbar()
        {
            Headerbar.SystemName = "نظام إدارة محل أدوات سباكة";
            Headerbar.UserName = "محمد جمال كساب";
            Headerbar.ButtonText = "نسخ احتياطي";
            Headerbar.ButtonImage = Resources.backup;
            Headerbar.ButtonWidth = 100;
            Headerbar.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            Headerbar.Height = 40;
            Headerbar.ActionClick += Headerbar_ButtonClicked;
        }

        private async void Headerbar_ButtonClicked(
            object sender,
            ucHeaderbar.ActionClickEventArgs e)
        {
            sfdBackup.FileName = $"Backup_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.db";

            string lastFolder = 
                StorePilot.UI.Properties.Settings.Default.LastBackupFolder;

            if (!string.IsNullOrWhiteSpace(lastFolder) &&
                Directory.Exists(lastFolder))
                sfdBackup.InitialDirectory = lastFolder;
            else
                sfdBackup.InitialDirectory = StartupManager.Folders.Backups;

            sfdBackup.RestoreDirectory = true;

            if (sfdBackup.ShowDialog() != DialogResult.OK)
                return;

            string databaseName = Path.GetFileNameWithoutExtension(sfdBackup.FileName);

            StartupManager.Folders.Backups = Path.GetDirectoryName(sfdBackup.FileName);

            string backupPath = await Task.Run(() => 
                DatabaseBackupManager.Backup(databaseName));

            StorePilot.UI.Properties.Settings.Default.LastBackupFolder = 
                Path.GetDirectoryName(backupPath);

            StorePilot.UI.Properties.Settings.Default.Save();

            MessageBoxManager.ShowSuccess(
                "تمت عملية النسخ الإحتياطي بنجاح.",
                Language.ar);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
            => OnClose?.Invoke(this);

        public delegate void ClosingAction(object sender);

        public event ClosingAction OnClose;
    }
}

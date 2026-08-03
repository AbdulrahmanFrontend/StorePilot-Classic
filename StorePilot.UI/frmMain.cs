using DevToolkit.BaseWinForms.Controls.UserControls;
using DevToolkit.BaseWinForms.Forms;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.BaseWinForms.Models;
using StorePilot.Core.Helpers;
using StorePilot.UI.Properties;
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
        //private ucDashboardScreen _dashboardScreen;
        //private UserControl _Screen;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _InitializeSidebar();

            //pnlContent.BackColor = AutoPartsColors.Background;

            _InitializeHeaderbar();
        }

        private void _InitializeSidebar()
        {
            //Sidebar.Logo = Resources.logo;
            //Sidebar.BackColor = AutoPartsColors.PrimaryDark;
            //Sidebar.ForeColor = AutoPartsColors.TextLight;
            //Sidebar.Font = AutoPartsFonts.Button;
            //Sidebar.SelectedButtonColor = AutoPartsColors.AccentBlue;

            Sidebar.Width = 150;

            Sidebar.Dock = DockStyle.Left;

            //Sidebar.ButtonsInfo = new List<NavigationItem>()
            //{
            //    new NavigationItem
            //    {
            //        Title = "الرئيسية",
            //        Icon = Resources.home,
            //        Index = 0,
            //    },
            //    new NavigationItem
            //    {
            //        Title = "المنتجات",
            //        Icon = Resources.product,
            //        Index = 1,
            //    },
            //    new NavigationItem
            //    {
            //        Title = "المبيعات",
            //        Icon = Resources.sales,
            //        Index = 2,
            //    },
            //    new NavigationItem
            //    {
            //        Title = "الزبائن",
            //        Icon = Resources.customer,
            //        Index = 3,
            //    },
            //    new NavigationItem
            //    {
            //        Title = "المشتريات",
            //        Icon = Resources.purchases,
            //        Index = 4,
            //    },
            //    new NavigationItem
            //    {
            //        Title = "الموردون",
            //        Icon = Resources.supplier,
            //        Index = 5,
            //    },
            //    new NavigationItem
            //    {
            //        Title = "الصندوق",
            //        Icon = Resources.cash,
            //        Index = 6,
            //    },
            //    //new NavigationItem
            //    //{
            //    //    Title = "التقارير",
            //    //    Icon = Resources.reports,
            //    //    Index = 7,
            //    //},
            //    //new NavigationItem
            //    //{
            //    //    Title = "الإعدادات",
            //    //    Icon = Resources.settings,
            //    //    Index = 8,
            //    //},
            //};

            Sidebar.SelectButton(0);

            //_dashboardScreen = new ucDashboardScreen();
            //_ShowScreen(_dashboardScreen);
            //_Screen = _dashboardScreen;

            //Sidebar.ScreenSelected += SelectScreen;

            //_dashboardScreen.ActionRequested += DashboardActionRequested;
        }

        private void SelectScreen(
            object sender,
            ucSidebar.ScreenSelectedEventArgs e)
        {
            //switch (e.Index)
            //{
            //    case 0:
            //        if (_Screen is ucDashboardScreen)
            //            return;
            //        _dashboardScreen = new ucDashboardScreen();
            //        _ShowScreen(_dashboardScreen);
            //        _dashboardScreen.ActionRequested += DashboardActionRequested;
            //        break;

            //    //case 1:
            //    //    if (_Screen is ucCategoriesScreen)
            //    //        return;
            //    //    _ShowScreen(new ucCategoriesScreen());
            //    //    break;

            //    case 1:
            //        if (_Screen is ucProductsScreen)
            //            return;
            //        _ShowScreen(new ucProductsScreen());
            //        break;

            //    case 2:
            //        if (_Screen is ucSalesScreen)
            //            return;
            //        _ShowScreen(new ucSalesScreen());
            //        break;

            //    case 3:
            //        if (_Screen is ucCustomersScreen)
            //            return;
            //        _ShowScreen(new ucCustomersScreen());
            //        break;

            //    case 4:
            //        if (_Screen is ucPurchasesScreen)
            //            return;
            //        _ShowScreen(new ucPurchasesScreen());
            //        break;

            //    case 5:
            //        if (_Screen is ucSuppliersScreen)
            //            return;
            //        _ShowScreen(new ucSuppliersScreen());
            //        break;

            //    case 6:
            //        if (_Screen is ucCashTransactionsScreen)
            //            return;
            //        _ShowScreen(new ucCashTransactionsScreen());
            //        break;

            //    case 7:
            //        if (_Screen is ucReportsScreen)
            //            return;
            //        _ShowScreen(new ucReportsScreen());
            //        break;

            //    case 8:
            //        if (_Screen is ucSettingsScreen)
            //            return;
            //        _ShowScreen(new ucSettingsScreen());
            //        break;

            //    default:
            //        _ShowScreen();
            //        break;
            //}
        }

        private void _ShowScreen(UserControl screen = null)
        {
            //_Screen = screen;
            //ScreenManager.ShowScreen(pnlContent, _Screen);
        }

        //private void DashboardActionRequested(
        //    object sender,
        //    ucDashboardScreen.DashboardActionEventArgs e)
        //{
        //    switch (e.Action)
        //    {
        //        case DashboardAction.NewProduct:
        //            _OpenScreen(new ucProductsScreen(), 1);
        //            break;

        //        case DashboardAction.NewSale:
        //            _OpenScreen(new ucSalesScreen(), 2);
        //            break;

        //        case DashboardAction.NewPayment:
        //            _OpenScreen(new ucSalesScreen(), 2);
        //            break;

        //        case DashboardAction.NewPurchase:
        //            _OpenScreen(new ucPurchasesScreen(), 4);
        //            break;

        //        default:
        //            _ShowScreen();
        //            break;
        //    }
        //}

        private void _OpenScreen(UserControl screen, int index)
        {
            _ShowScreen(screen);

            Sidebar.SelectButton(index);
        }

        private void _InitializeHeaderbar()
        {
            Headerbar.SystemName = "نظام إدارة محل قطع غيار سيارات";
            Headerbar.UserName = "سيد عبدالعليم";
            //Headerbar.ButtonImage = Resources.backup;
            //Headerbar.ButtonWidth = 90;
            //Headerbar.ButtonText = "نسخ احتياطي";

            //Headerbar.BackColor = AutoPartsColors.Primary;
            //Headerbar.ForeColor = AutoPartsColors.TextLight;
            //Headerbar.Font = AutoPartsFonts.SubHeader;

            //Headerbar.ButtonColor = AutoPartsColors.AccentBlue;
            Headerbar.ActionClick += Headerbar_ActionClick;
        }

        private void Headerbar_ActionClick(
            object sender,
            ucHeaderbar.ActionClickEventArgs e)
        {
            //sfdBackup.FileName =
            //    $"Backup_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.db";

            //string lastFolder = Properties.Settings.Default.LastBackupFolder;

            //if (!string.IsNullOrWhiteSpace(lastFolder) &&
            //    Directory.Exists(lastFolder))
            //{
            //    sfdBackup.InitialDirectory = lastFolder;
            //}
            //else
            //{
            //    sfdBackup.InitialDirectory =
            //        Path.GetDirectoryName(AppPaths.BackupFolder);
            //}

            //sfdBackup.RestoreDirectory = true;

            //if (sfdBackup.ShowDialog() != DialogResult.OK)
            //    return;

            //var result = BackupService.CreateBackup(sfdBackup.FileName);

            //if (result.IsSuccess)
            //{
            //    Properties.Settings.Default.LastBackupFolder =
            //        Path.GetDirectoryName(sfdBackup.FileName);

            //    Properties.Settings.Default.Save();

            //    MessageBoxManager.ShowSuccess(
            //        result.Message,
            //        Language.ar);
            //}
            //else
            //{
            //    MessageBoxManager.ShowError(
            //        result.Message,
            //        Language.ar);
            //}
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
            => OnClose?.Invoke(this);

        public delegate void ClosingAction(object sender);

        public event ClosingAction OnClose;
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Theme;
using StorePilot.WinForms.ViewModels;

namespace StorePilot.WinForms.Pages
{
    public partial class DashboardPage : UserControl
    {
        private readonly AppBrandSettingsStore _settingsStore;
        private readonly DashboardViewModel _viewModel;

        public DashboardPage(AppBrandSettingsStore settingsStore)
        {
            _settingsStore = settingsStore ??
                             throw new ArgumentNullException(nameof(settingsStore));

            _viewModel = DashboardViewModel.CreateDemo();

            InitializeComponent();

            RightToLeft = RightToLeft.Yes;
            Load += DashboardPage_Load;
        }

        private void DashboardPage_Load(object? sender, EventArgs e)
        {
            LoadSettings();
            LoadDashboardData();
        }

        private void LoadSettings()
        {
            var settings = _settingsStore.Load();

            storeNameLabel.Text = string.IsNullOrWhiteSpace(settings.StoreName)
                ? "StorePilot"
                : settings.StoreName;

            welcomeUserLabel.Text = string.IsNullOrWhiteSpace(settings.UserName)
                ? "مرحباً بك"
                : $"مرحباً بك، {settings.UserName}";

            AppTheme.Set(settings.Theme);
            AppTheme.Apply(this);
        }

        private void LoadDashboardData()
        {
            todaySalesValueLabel.Text = _viewModel.TodaySales;
            todayPurchasesValueLabel.Text = _viewModel.TodayPurchases;
            totalDebtsValueLabel.Text = _viewModel.TotalDebts;
            productsValueLabel.Text = _viewModel.ProductsCount;
            lowStockValueLabel.Text = _viewModel.LowStockCount;

            recentSalesGrid.Rows.Clear();

            foreach (var sale in _viewModel.RecentSales)
            {
                recentSalesGrid.Rows.Add(
                    sale.InvoiceNumber == null ? string.Empty : sale.InvoiceNumber,
                    sale.CustomerName == null ? string.Empty : sale.CustomerName,
                    sale.Total == null ? string.Empty : sale.Total.ToString(),
                    sale.PaymentStatus == null ? string.Empty : sale.PaymentStatus,
                    sale.Date.ToString("HH:mm")
                );
            }

            lowStockGrid.Rows.Clear();

            foreach (var item in _viewModel.LowStockItems)
            {
                lowStockGrid.Rows.Add(
                    item.ProductName == null ? string.Empty : item.ProductName,
                    item.CurrentQuantity,
                    item.MinimumQuantity
                );
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadSettings();
            LoadDashboardData();
        }
    }
}
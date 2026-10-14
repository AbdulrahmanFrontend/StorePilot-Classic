using StorePilot.Application.Dtos.DashboardDtos;
using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Theme;
using StorePilot.WinForms.ViewModels;

namespace StorePilot.WinForms.Pages
{
    public partial class DashboardPage : UserControl
    {
        private readonly AppBrandSettingsStore _settingsStore;
        private readonly DashboardViewModel _viewModel;

        public DashboardPage(
            AppBrandSettingsStore settingsStore,
            DashboardViewModel viewModel)
        {
            _settingsStore = settingsStore ??
                             throw new ArgumentNullException(
                                 nameof(settingsStore));

            _viewModel = viewModel ??
                             throw new ArgumentNullException(
                                 nameof(viewModel));

            InitializeComponent();
        }

        private void DashboardPage_Load(object? sender, EventArgs e)
        {
            LoadSettings();
            LoadDashboardData();
        }

        public void LoadSettings()
        {
            var settings = _settingsStore.Load();

            storeNameLabel.Text = 
                string.IsNullOrWhiteSpace(settings.StoreName)
                ? "StorePilot"
                : settings.StoreName;

            welcomeUserLabel.Text = 
                string.IsNullOrWhiteSpace(settings.UserName)
                ? "مرحباً بك"
                : $"مرحباً بك، {settings.UserName}";

            AppTheme.Set(settings.Theme);
            AppTheme.Apply(this);
        }

        private void LoadDashboardData()
        {
            var dashboardData = _viewModel.GetDashboardDataAsync().Result.Value;
            todaySalesValueLabel.Text = dashboardData?.TodaySales.ToString("C");
            todayPurchasesValueLabel.Text = 
                dashboardData?.TodayPurchases.ToString("C");
            totalDebtsValueLabel.Text = dashboardData?.TotalDebts.ToString("C");
            productsValueLabel.Text = dashboardData?.ProductsCount.ToString();
            lowStockValueLabel.Text = dashboardData?.LowStockCount.ToString();

            recentSalesGrid.Rows.Clear();

            var recentSalesItems = dashboardData?.RecentSalesItems ??
                Enumerable.Empty<RecentSaleItemDto>();

            foreach (var sale in recentSalesItems)
            {
                recentSalesGrid.Rows.Add(
                    sale.InvoiceNumber,
                    sale.CustomerName,
                    sale.TotalAmount.ToString(),
                    sale.Status,
                    sale.SaleDate.ToString("HH:mm")
                );
            }

            lowStockGrid.Rows.Clear();

            var lowStockItems = dashboardData?.LowStockItems ??
                Enumerable.Empty<LowStockItemDto>();

            foreach (var item in lowStockItems)
            {
                lowStockGrid.Rows.Add(
                    item.ProductName,
                    item.CurrentStock,
                    item.MinimumStock
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
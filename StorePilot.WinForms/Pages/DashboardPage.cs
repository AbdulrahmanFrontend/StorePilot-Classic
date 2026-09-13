using StorePilot.WinForms.Controls;
using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.Pages;

public partial class DashboardPage : UserControl
{
    readonly DemoDataStore data = DemoDataStore.Instance;

    public DashboardPage()
    {
        InitializeComponent();
        RefreshData();
        ApplyTheme();
    }

    void RefreshData()
    {
        sales.Value = data.TodaySales.ToString("N2");
        customers.Value = data.CustomerBalances.ToString("N2");
        suppliers.Value = data.SupplierBalances.ToString("N2");
        low.Value = data.LowStock.ToString();
        salesGrid.DataSource = data.Sales
            .OrderByDescending(x => x.Date)
            .Take(5)
            .Select(x => new
            {
                الرقم = x.Number,
                التاريخ = x.Date.ToString("dd/MM/yyyy HH:mm"),
                العميل = x.Party,
                الإجمالي = x.Total.ToString("N2"),
                الحالة = x.Status
            })
            .ToList();

        lowGrid.DataSource = data.Products
            .Where(x => x.Active && x.Quantity <= x.MinQuantity)
            .Select(x => new
            {
                الكود = x.Code,
                الصنف = x.Name,
                الكمية = x.Quantity,
                الحد_الأدنى = x.MinQuantity
            })
            .ToList();
    }

    public void ApplyTheme()
    {
        BackColor = AppTheme.Background;
        header.ApplyTheme();
        sales.ApplyTheme();
        customers.ApplyTheme();
        suppliers.ApplyTheme();
        low.ApplyTheme();
        recent.StateCommon.Color1 = AppTheme.Surface;
        alerts.StateCommon.Color1 = AppTheme.Surface;
    }
}

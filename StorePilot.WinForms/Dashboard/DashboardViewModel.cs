using System.Collections.Generic;

namespace StorePilot.WinForms.Dashboard;

public sealed class DashboardViewModel
{
    public decimal TodaySales { get; set; }
    public decimal TodayPurchases { get; set; }
    public decimal CustomerDebts { get; set; }
    public decimal SupplierDebts { get; set; }

    public int ActiveProducts { get; set; }
    public int ActiveCustomers { get; set; }
    public int ActiveSuppliers { get; set; }

    public List<SalesPoint> SalesChart { get; set; } = new();

    public List<RecentActivityItem> RecentActivities { get; set; } = new();
}
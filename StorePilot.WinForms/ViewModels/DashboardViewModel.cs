using System;
using System.Collections.Generic;

namespace StorePilot.WinForms.ViewModels;

public sealed class DashboardViewModel
{
    public string? TodaySales { get; set; }
    public string? TodayPurchases { get; set; }
    public string? TotalDebts { get; set; }
    public string? ProductsCount { get; set; }
    public string? LowStockCount { get; set; }

    public List<RecentSaleItem> RecentSales { get; } =
        new List<RecentSaleItem>();

    public List<LowStockItem> LowStockItems { get; } =
        new List<LowStockItem>();

    public static DashboardViewModel CreateDemo()
    {
        var model = new DashboardViewModel
        {
            TodaySales = "12,450.00",
            TodayPurchases = "7,820.00",
            TotalDebts = "18,350.00",
            ProductsCount = "1,248",
            LowStockCount = "14"
        };

        model.RecentSales.Add(new RecentSaleItem
        {
            InvoiceNumber = "INV-1001",
            CustomerName = "عميل نقدي",
            Total = "1,250.00",
            PaymentStatus = "مدفوعة",
            Date = DateTime.Now.AddMinutes(-15)
        });

        model.RecentSales.Add(new RecentSaleItem
        {
            InvoiceNumber = "INV-1000",
            CustomerName = "محمد أحمد",
            Total = "850.00",
            PaymentStatus = "آجلة",
            Date = DateTime.Now.AddHours(-1)
        });

        model.RecentSales.Add(new RecentSaleItem
        {
            InvoiceNumber = "INV-0999",
            CustomerName = "شركة النور",
            Total = "2,400.00",
            PaymentStatus = "مدفوعة",
            Date = DateTime.Now.AddHours(-2)
        });

        model.RecentSales.Add(new RecentSaleItem
        {
            InvoiceNumber = "INV-0998",
            CustomerName = "عميل نقدي",
            Total = "675.00",
            PaymentStatus = "مدفوعة",
            Date = DateTime.Now.AddHours(-3)
        });

        model.LowStockItems.Add(new LowStockItem
        {
            ProductName = "محبس نحاس 1/2 بوصة",
            CurrentQuantity = 3,
            MinimumQuantity = 10
        });

        model.LowStockItems.Add(new LowStockItem
        {
            ProductName = "كوع PVC 3/4 بوصة",
            CurrentQuantity = 5,
            MinimumQuantity = 15
        });

        model.LowStockItems.Add(new LowStockItem
        {
            ProductName = "شريط تفلون",
            CurrentQuantity = 4,
            MinimumQuantity = 20
        });

        model.LowStockItems.Add(new LowStockItem
        {
            ProductName = "وصلة نحاس 1 بوصة",
            CurrentQuantity = 2,
            MinimumQuantity = 8
        });

        return model;
    }
}
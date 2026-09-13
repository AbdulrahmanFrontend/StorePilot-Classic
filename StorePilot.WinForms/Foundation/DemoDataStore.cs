using StorePilot.WinForms.Foundation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Foundation;

public sealed class DemoDataStore
{
    public static DemoDataStore Instance { get; } = new();

    public List<DemoProduct> Products { get; } =
    [
        new(1, "P-1001", "ماسورة PVC 1 بوصة", "مواسير", "قطعة", 120, 20, 85, true),
        new(2, "P-1002", "ماسورة PVC 2 بوصة", "مواسير", "قطعة", 18, 20, 145, true),
        new(3, "V-2001", "محبس نحاس 1 بوصة", "محابس", "قطعة", 35, 10, 210, true), 
        new(4, "F-3001", "كوع PVC 1 بوصة", "وصلات", "قطعة", 220, 50, 28, true), 
        new(5, "F-3002", "تيه PVC 1 بوصة", "وصلات", "قطعة", 9, 30, 34, true), 
        new(6, "T-4001", "شريط تفلون", "أدوات", "قطعة", 75, 15, 18, true),
        new(7, "A-5001", "خرطوم مرن 60 سم", "خراطيم", "قطعة", 42, 10, 95, true), 
        new(8, "A-5002", "خرطوم غسالة", "خراطيم", "قطعة", 6, 10, 125, true), 
        new(9, "P-1003", "ماسورة صرف 3 بوصة", "مواسير", "قطعة", 0, 10, 190, true),
        new(10, "V-2002", "محبس زاوية", "محابس", "قطعة", 28, 8, 125, true)
    ];

    public List<DemoParty> Customers { get; } = 
    [
        new(1, "مؤسسة النور", "01000000001", "القاهرة", 18500, 12000, 6500, true),
        new(2, "محمد أحمد", "01000000002", "الجيزة", 7200, 7200, 0, true), 
        new(3, "شركة الإعمار", "01000000003", "القاهرة", 32000, 21000, 11000, true), 
        new(4, "أحمد محمود", "01000000004", "القليوبية", 4500, 2500, 2000, true)
    ];

    public List<DemoParty> Suppliers { get; } = 
    [
        new(1, "شركة النيل للتوريدات", "01100000001", "القاهرة", 28000, 22000, 6000, true), 
        new(2, "مصنع الخليج", "01100000002", "العاشر من رمضان", 41500, 31500, 10000, true),
        new(3, "مخازن المتحدة", "01100000003", "القاهرة", 12500, 12500, 0, true)
    ];

    public List<DemoInvoice> Sales { get; } = 
    [
        new("S-000124", DateTime.Today.AddMinutes(-25), "مؤسسة النور", 1850, "آجل"),
        new("S-000123", DateTime.Today.AddHours(-2), "محمد أحمد", 920, "نقدي"),
        new("S-000122", DateTime.Today.AddHours(-4), "شركة الإعمار", 3750, "آجل"),
        new("S-000121", DateTime.Today.AddDays(-1), "أحمد محمود", 680, "نقدي"), 
        new("S-000120", DateTime.Today.AddDays(-1), "مؤسسة النور", 2140, "نقدي")
    ];

    public decimal TodaySales => 
        Sales.Where(x => x.Date.Date == DateTime.Today).Sum(x => x.Total);

    public decimal CustomerBalances => Customers.Sum(x => x.Balance);

    public decimal SupplierBalances => Suppliers.Sum(x => x.Balance);

    public int LowStock => Products.Count(x => x.Active && x.Quantity <= x.MinQuantity);
}

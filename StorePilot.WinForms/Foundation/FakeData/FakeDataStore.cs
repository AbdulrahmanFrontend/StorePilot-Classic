using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Foundation.FakeData
{
    public sealed class FakeDataStore
    {
        private static readonly Lazy<FakeDataStore> _instance =
            new Lazy<FakeDataStore>(() => new FakeDataStore());

        public static FakeDataStore Instance => _instance.Value;

        public List<FakeProduct> Products { get; } = new();
        public List<FakeParty> Customers { get; } = new();
        public List<FakeParty> Suppliers { get; } = new();
        public List<FakeReferenceItem> Groups { get; } = new();
        public List<FakeReferenceItem> Units { get; } = new();
        public List<FakeReferenceItem> PaymentMethods { get; } = new();
        public List<FakeInvoice> RecentSales { get; } = new();

        private FakeDataStore()
        {
            Seed();
        }

        private void Seed()
        {
            Groups.AddRange(new[]
            {
                new FakeReferenceItem { Id = 1, Name = "مواسير" },
                new FakeReferenceItem { Id = 2, Name = "وصلات" },
                new FakeReferenceItem { Id = 3, Name = "محابس" },
                new FakeReferenceItem { Id = 4, Name = "خلاطات" },
                new FakeReferenceItem { Id = 5, Name = "أدوات صحية" }
            });

            Units.AddRange(new[]
            {
                new FakeReferenceItem { Id = 1, Name = "قطعة" },
                new FakeReferenceItem { Id = 2, Name = "متر" },
                new FakeReferenceItem { Id = 3, Name = "كرتونة" },
                new FakeReferenceItem { Id = 4, Name = "لفة" }
            });

            PaymentMethods.AddRange(new[]
            {
                new FakeReferenceItem { Id = 1, Name = "نقدي" },
                new FakeReferenceItem { Id = 2, Name = "تحويل بنكي" },
                new FakeReferenceItem { Id = 3, Name = "آجل" }
            });

            Products.AddRange(new[]
            {
                new FakeProduct { Id=1, Code="P-1001", Name="ماسورة PVC 1 بوصة", Group="مواسير", Unit="متر", Quantity=86, MinQuantity=20, SalePrice=72, PurchasePrice=55 },
                new FakeProduct { Id=2, Code="P-1002", Name="كوع PVC 1 بوصة", Group="وصلات", Unit="قطعة", Quantity=14, MinQuantity=20, SalePrice=18, PurchasePrice=12 },
                new FakeProduct { Id=3, Code="P-1003", Name="محبس نحاس 1 بوصة", Group="محابس", Unit="قطعة", Quantity=31, MinQuantity=10, SalePrice=145, PurchasePrice=118 },
                new FakeProduct { Id=4, Code="P-1004", Name="خلاط حوض اقتصادي", Group="خلاطات", Unit="قطعة", Quantity=8, MinQuantity=10, SalePrice=680, PurchasePrice=560 },
                new FakeProduct { Id=5, Code="P-1005", Name="سيفون حوض", Group="أدوات صحية", Unit="قطعة", Quantity=25, MinQuantity=8, SalePrice=95, PurchasePrice=71 },
                new FakeProduct { Id=6, Code="P-1006", Name="شريط تيفلون", Group="وصلات", Unit="لفة", Quantity=5, MinQuantity=12, SalePrice=22, PurchasePrice=15 },
                new FakeProduct { Id=7, Code="P-1007", Name="ماسورة PPR 20mm", Group="مواسير", Unit="متر", Quantity=120, MinQuantity=30, SalePrice=48, PurchasePrice=36 },
                new FakeProduct { Id=8, Code="P-1008", Name="كوع PPR 20mm", Group="وصلات", Unit="قطعة", Quantity=42, MinQuantity=15, SalePrice=12, PurchasePrice=8 }
            });

            Customers.AddRange(new[]
            {
                new FakeParty { Id=1, Name="أحمد محمد", Phone="01000000001", Address="القاهرة", Total=18450, Paid=12000, Balance=6450 },
                new FakeParty { Id=2, Name="مؤسسة النور", Phone="01000000002", Address="الجيزة", Total=32700, Paid=32700, Balance=0 },
                new FakeParty { Id=3, Name="محمد السيد", Phone="01000000003", Address="شبرا", Total=9800, Paid=5000, Balance=4800 },
                new FakeParty { Id=4, Name="شركة البناء الحديث", Phone="01000000004", Address="مدينة نصر", Total=56400, Paid=40000, Balance=16400 }
            });

            Suppliers.AddRange(new[]
            {
                new FakeParty { Id=1, Name="شركة النخبة للمواسير", Phone="01100000001", Address="العاشر من رمضان", Total=48500, Paid=30000, Balance=18500 },
                new FakeParty { Id=2, Name="مورد الأدوات الصحية", Phone="01100000002", Address="العبور", Total=27100, Paid=27100, Balance=0 },
                new FakeParty { Id=3, Name="مصنع الوصلات الحديثة", Phone="01100000003", Address="6 أكتوبر", Total=19300, Paid=10000, Balance=9300 }
            });

            RecentSales.AddRange(new[]
            {
                new FakeInvoice { Id=1, Number="S-000125", Date=DateTime.Today.AddMinutes(-35), Party="أحمد محمد", Total=2450, Status="مكتملة" },
                new FakeInvoice { Id=2, Number="S-000124", Date=DateTime.Today.AddHours(-2), Party="مؤسسة النور", Total=6180, Status="مكتملة" },
                new FakeInvoice { Id=3, Number="S-000123", Date=DateTime.Today.AddHours(-4), Party="محمد السيد", Total=1290, Status="آجل" },
                new FakeInvoice { Id=4, Number="S-000122", Date=DateTime.Today.AddDays(-1), Party="شركة البناء الحديث", Total=8750, Status="مكتملة" }
            });
        }

        public decimal TodaySales =>
            RecentSales.Where(x => x.Date.Date == DateTime.Today).Sum(x => x.Total);

        public decimal CustomerBalances =>
            Customers.Sum(x => x.Balance);

        public decimal SupplierBalances =>
            Suppliers.Sum(x => x.Balance);

        public int LowStockCount =>
            Products.Count(x => x.Active && x.Quantity <= x.MinQuantity);

        public void AddProduct(FakeProduct product)
        {
            product.Id = Products.Count == 0 ? 1 : Products.Max(x => x.Id) + 1;
            Products.Add(product);
        }

        public void AddCustomer(FakeParty party)
        {
            party.Id = Customers.Count == 0 ? 1 : Customers.Max(x => x.Id) + 1;
            Customers.Add(party);
        }

        public void AddSupplier(FakeParty party)
        {
            party.Id = Suppliers.Count == 0 ? 1 : Suppliers.Max(x => x.Id) + 1;
            Suppliers.Add(party);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using StorePilot.Domain.Entities;

namespace StorePilot.Application.Interfaces;

public interface IAppDbContext
{
    DbSet<Product> Products { get; }
    //DbSet<Customer> Customers { get; }
    //DbSet<Supplier> Suppliers { get; }
    //DbSet<Person> People { get; }
    DbSet<Unit> Units { get; }
    DbSet<ProductGroup> ProductGroups { get; }
    DbSet<PaymentMethod> PaymentMethods { get; }

    //DbSet<SaleInvoice> SaleInvoices { get; }
    //DbSet<SaleInvoiceItem> SaleInvoiceItems { get; }
    //DbSet<PurchaseInvoice> PurchaseInvoices { get; }
    //DbSet<PurchaseInvoiceItem> PurchaseInvoiceItems { get; }

    //DbSet<SaleReturn> SaleReturns { get; }
    //DbSet<SaleReturnItem> SaleReturnItems { get; }
    //DbSet<PurchaseReturn> PurchaseReturns { get; }
    //DbSet<PurchaseReturnItem> PurchaseReturnItems { get; }

    //DbSet<CustomerPayment> CustomerPayments { get; }
    //DbSet<SupplierPayment> SupplierPayments { get; }
    //DbSet<OldCustomerDebt> OldCustomerDebts { get; }

    //DbSet<CashTransaction> CashTransactions { get; }
    //DbSet<StockTransaction> StockTransactions { get; }
    //DbSet<Quotation> Quotations { get; }
    //DbSet<QuotationItem> QuotationItems { get; }

    // 2. دوال الحفظ والعمليات الأساسية
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}

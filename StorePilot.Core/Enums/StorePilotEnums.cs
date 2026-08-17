using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Enums
{
    public enum TransactionType
    {
        Revenue = 0,
        Expense = 1,
    }

    public enum InvoiceStatus
    {
        Paid = 0,
        Deferred = 1,
    }

    public enum FilterMethodsPeople
    {
        Name = 0,
        Phone = 1,
        Address = 2,
    }

    public enum FilterMethodsProducts
    {
        ProductName = 0,
        BarCode = 1,
        Group = 2,
        Unit = 3,
    }

    public enum FilterMethodsCash
    {
        TransactionDate = 0,
        TransactionType = 1,
        Description = 2,
    }

    public enum FilterMethodsSalesInvoices
    {
        SaleInvoiceID = 0,
        InvoiceID = 1,
        CustomerName = 2,
        InvoiceDate = 3,
        InvoiceStatus = 4,
    }

    public enum FilterMethodsPurchasesInvoices
    {
        PurchaseInvoiceID = 0,
        InvoiceID = 1,
        SupplierName = 2,
        InvoiceDate = 3,
        InvoiceStatus = 4,
    }

    public enum FilterMethodsPayments 
    { 
        PaymentID = 0,
        InvoiceID = 1,
        PaymentDate = 2,
        PaymentMethod = 3,
    }

    public enum FilterMethodsSalesReturns
    {
        ReturnID = 0,
        SaleInvoiceID = 1,
        ReturnDate = 2,
    }
}

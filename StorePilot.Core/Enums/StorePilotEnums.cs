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
        Name = 1,
        Phone = 2,
        Address = 3,
    }

    public enum FilterMethodsProducts
    {
        ProductName = 1,
        Unit = 2,
        Group = 3,
        BarCode = 4,
    }

    public enum FilterMethodsCash
    {
        TransactionDate = 1,
        Type = 2,
        Description = 3,
    }

    public enum FilterMethodsInvoices
    {
        Name = 1,
        InvoiceDate = 2,
        InvoiceStatus = 3,
    }

    public enum FilterMethodsPayments 
    { 
        PaymentDate = 1,
        PaymentMethod = 2,
    }
}

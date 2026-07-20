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

    public enum SalesInvoiceStatus
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
}

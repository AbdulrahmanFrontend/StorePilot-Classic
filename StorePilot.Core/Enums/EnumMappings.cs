using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Enums
{
    public static class EnumMappings
    {
        public static string ToArabic(this TransactionType type)
        {
            switch (type)
            {
                case TransactionType.Revenue: return "ايرادات";
                case TransactionType.Expense: return "مصروفات";
                default: throw new ArgumentOutOfRangeException(nameof(type));
            }
        }

        public static TransactionType ToTransactionType(this string value)
        {
            switch (value)
            {
                case "ايرادات": return TransactionType.Revenue;
                case "مصروفات": return TransactionType.Expense;
                default:
                    throw new ArgumentException($"نوع حركة غير معروف!");
            }
        }

        // ---------- SalesInvoiceStatus ----------

        public static string ToArabic(this SalesInvoiceStatus status)
        {
            switch (status)
            {
                case SalesInvoiceStatus.Paid: return "مدفوع";
                case SalesInvoiceStatus.Deferred: return "آجل";
                default: throw new ArgumentOutOfRangeException(nameof(status));
            }
        }

        public static SalesInvoiceStatus ToSalesInvoiceStatus(this string value)
        {
            switch (value)
            {
                case "مدفوع": return SalesInvoiceStatus.Paid;
                case "آجل": return SalesInvoiceStatus.Deferred;
                default:
                    throw new ArgumentException($"حالة فاتورة غير معرفة!");
            }
        }
    }
}

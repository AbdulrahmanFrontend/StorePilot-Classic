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

        public static string ToArabic(this InvoiceStatus status)
        {
            switch (status)
            {
                case InvoiceStatus.Paid: return "مدفوع";
                case InvoiceStatus.Deferred: return "آجل";
                default: throw new ArgumentOutOfRangeException(nameof(status));
            }
        }

        public static InvoiceStatus ToInvoiceStatus(this string value)
        {
            switch (value)
            {
                case "مدفوع": return InvoiceStatus.Paid;
                case "آجل": return InvoiceStatus.Deferred;
                default:
                    throw new ArgumentException($"حالة فاتورة غير معرفة!");
            }
        }
    }
}

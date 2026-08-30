using StorePilot.Core.Printing;
using StorePilot.UI.Printing.PrintDocumentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.UI.Printing.Builders
{
    /// <summary>
    /// Configures the shared TablePrintDocument engine for a Sales Invoice —
    /// items table (Group / Unit / Name / Quantity / Unit Price / Total, no barcode,
    /// no ProductID), invoice date shown alongside the items, and an optional
    /// payment-history sub-table when the invoice has any recorded payments.
    /// </summary>
    public static class SalesInvoicePrintBuilder
    {
        public static TablePrintDocument Build(PrintableSalesInvoice invoice, string shopName)
        {
            var model = new PrintDocumentModel
            {
                ShopName = shopName,
                DocumentTitle = "فاتورة مبيعات",

                ReferenceLines = new List<(string, string)>
                {
                    ("رقم فاتورة البيع", invoice.ReferenceID.ToString()),
                    ("الرقم العام للفاتورة", invoice.InvoiceID.ToString())
                },

                HeaderInfoLines = new List<(string, string)>
                {
                    ("التاريخ", invoice.InvoiceDate.ToString("yyyy/MM/dd  hh:mm tt")),
                    ("العميل", string.IsNullOrWhiteSpace(invoice.PartyName) ? "عميل نقدي" : invoice.PartyName),
                    ("حالة الفاتورة", invoice.StatusText)
                },

                Columns = BuildItemColumns(),
                Rows = invoice.Items.Cast<object>().ToList(),

                SummaryLines = new List<(string, string)>
                {
                    ("الإجمالي", invoice.TotalAmount.ToString("N2")),
                    ("المدفوع", invoice.PaidAmount.ToString("N2")),
                    ("المتبقي", invoice.RemainingAmount.ToString("N2"))
                },

                FooterNote = "شكراً لتعاملكم معنا"
            };

            if (invoice.Payments != null && invoice.Payments.Count > 0)
            {
                model.ExtraSection = new PrintSubSection
                {
                    Title = "سجل الدفعات",
                    Columns = BuildPaymentColumns(),
                    Rows = invoice.Payments.Cast<object>().ToList()
                };
            }

            return new TablePrintDocument(model);
        }

        private static List<PrintColumn> BuildItemColumns() => new List<PrintColumn>
        {
            new PrintColumn { Header = "المجموعة",   WidthPercent = 16, ValueSelector = o => ((PrintableLineItem)o).GroupName },
            new PrintColumn { Header = "الوحدة",     WidthPercent = 10, ValueSelector = o => ((PrintableLineItem)o).UnitName },
            new PrintColumn { Header = "الصنف",      WidthPercent = 30, ValueSelector = o => ((PrintableLineItem)o).ProductName },
            new PrintColumn { Header = "الكمية",     WidthPercent = 12, ValueSelector = o => ((PrintableLineItem)o).Quantity.ToString("0.##") },
            new PrintColumn { Header = "سعر الوحدة", WidthPercent = 16, ValueSelector = o => ((PrintableLineItem)o).UnitPrice.ToString("N2") },
            new PrintColumn { Header = "الإجمالي",   WidthPercent = 16, ValueSelector = o => ((PrintableLineItem)o).TotalPrice.ToString("N2") },
        };

        private static List<PrintColumn> BuildPaymentColumns() => new List<PrintColumn>
        {
            new PrintColumn { Header = "رقم الإيصال", WidthPercent = 18, ValueSelector = o => ((PrintablePayment)o).PaymentID.ToString() },
            new PrintColumn { Header = "التاريخ",      WidthPercent = 26, ValueSelector = o => ((PrintablePayment)o).PaymentDate.ToString("yyyy/MM/dd") },
            new PrintColumn { Header = "طريقة الدفع",  WidthPercent = 26, ValueSelector = o => ((PrintablePayment)o).MethodName },
            new PrintColumn { Header = "المبلغ",       WidthPercent = 30, ValueSelector = o => ((PrintablePayment)o).PaidAmount.ToString("N2") },
        };
    }
}

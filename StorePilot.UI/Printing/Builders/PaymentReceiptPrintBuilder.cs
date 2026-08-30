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
    /// A payment receipt has no items table — just a reference number,
    /// a few info lines and a totals block. Leaving Columns/Rows empty
    /// on PrintDocumentModel makes the engine skip the table section entirely.
    /// </summary>
    public static class PaymentReceiptPrintBuilder
    {
        public static TablePrintDocument Build(PrintablePaymentReceipt receipt, string shopName)
        {
            var model = new PrintDocumentModel
            {
                ShopName = shopName,
                DocumentTitle = "إيصال سداد",

                ReferenceLines = new List<(string, string)>
                {
                    ("رقم الإيصال", receipt.PaymentID.ToString()),
                    ($"رقم {receipt.InvoiceKindLabel}", receipt.RelatedInvoiceReferenceID.ToString()),
                    ("الرقم العام للفاتورة", receipt.RelatedInvoiceID.ToString())
                },

                HeaderInfoLines = new List<(string, string)>
                {
                    ("التاريخ", receipt.PaymentDate.ToString("yyyy/MM/dd  hh:mm tt")),
                    ("الطرف", string.IsNullOrWhiteSpace(receipt.PartyName) ? "غير محدد" : receipt.PartyName),
                    ("طريقة الدفع", receipt.MethodName),
                    ("نوع الفاتورة", receipt.InvoiceKindLabel)
                },

                SummaryLines = new List<(string, string)>
                {
                    ("المبلغ المسدد الآن", receipt.PaidAmount.ToString("N2")),
                    ("إجمالي الفاتورة", receipt.InvoiceTotalAmount.ToString("N2")),
                    ("المتبقي بعد هذا السداد", receipt.InvoiceRemainingAmount.ToString("N2"))
                },

                FooterNote = string.IsNullOrWhiteSpace(receipt.Notes) ? "شكراً لتعاملكم معنا" : "ملاحظات: " + receipt.Notes
            };

            return new TablePrintDocument(model);
        }
    }
}

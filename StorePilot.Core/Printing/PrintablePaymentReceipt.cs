using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Printing
{
    /// <summary>Everything needed to print a standalone payment receipt.</summary>
    public class PrintablePaymentReceipt
    {
        /// <summary>Payments.PaymentID — the receipt's own reference number.</summary>
        public int PaymentID { get; set; }

        /// <summary>Invoices.InvoiceID of the invoice this payment was applied to.</summary>
        public int RelatedInvoiceID { get; set; }

        /// <summary>SaleInvoiceID or PurchaseInvoiceID of the related invoice, whichever applies.</summary>
        public int RelatedInvoiceReferenceID { get; set; }

        /// <summary>"فاتورة بيع" أو "فاتورة شراء" — tells the builder/printer which invoice kind this receipt belongs to.</summary>
        public string InvoiceKindLabel { get; set; }

        public DateTime PaymentDate { get; set; }
        public decimal PaidAmount { get; set; }
        public string MethodName { get; set; }
        public string PartyName { get; set; }
        public decimal InvoiceTotalAmount { get; set; }

        /// <summary>Invoice's PaidAmount AFTER this payment was applied (comes straight from Invoices.PaidAmount).</summary>
        public decimal InvoiceRemainingAmount { get; set; }

        public string Notes { get; set; }
    }
}

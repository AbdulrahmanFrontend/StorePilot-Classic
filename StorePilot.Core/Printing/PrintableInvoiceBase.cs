using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Printing
{
    /// <summary>
    /// Shared shape for both Sales and Purchase invoices.
    /// Carries BOTH reference numbers on purpose: the shared Invoices.InvoiceID
    /// and the type-specific SaleInvoiceID / PurchaseInvoiceID — printing both
    /// is exactly what makes the receipt hard to forge (both must match on lookup).
    /// </summary>
    public abstract class PrintableInvoiceBase
    {
        /// <summary>Invoices.InvoiceID — the shared/general reference number.</summary>
        public int InvoiceID { get; set; }

        /// <summary>SalesInvoices.SaleInvoiceID or PurchasesInvoices.PurchaseInvoiceID — the type-specific reference number.</summary>
        public int ReferenceID { get; set; }

        public DateTime InvoiceDate { get; set; }

        /// <summary>Display text for InvoiceStatus ("مدفوع" / "آجل").</summary>
        public string StatusText { get; set; }

        /// <summary>Customer name (sales) or Supplier name (purchases). Null/empty => cash/walk-in party.</summary>
        public string PartyName { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount => TotalAmount - PaidAmount;

        public List<PrintableLineItem> Items { get; set; } = new List<PrintableLineItem>();
        public List<PrintablePayment> Payments { get; set; } = new List<PrintablePayment>();
        public string Notes { get; set; }
    }
}

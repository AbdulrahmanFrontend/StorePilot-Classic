using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Printing
{
    /// <summary>Everything needed to print a Sales Return slip.</summary>
    public class PrintableSalesReturn
    {
        /// <summary>SalesReturns.ReturnID — the return's own reference number.</summary>
        public int ReturnID { get; set; }

        /// <summary>SalesInvoices.SaleInvoiceID this return belongs to — printed for cross-checking.</summary>
        public int RelatedSaleInvoiceReferenceID { get; set; }

        public DateTime ReturnDate { get; set; }
        public decimal TotalReturnAmount { get; set; }
        public List<PrintableLineItem> Items { get; set; } = new List<PrintableLineItem>();
        public string Notes { get; set; }
    }
}

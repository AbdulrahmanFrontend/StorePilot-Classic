using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Printing
{
    /// <summary>One installment/payment row, printed under an invoice or as its own receipt.</summary>
    public class PrintablePayment
    {
        /// <summary>Payments.PaymentID — the customer-facing reference number for this receipt.</summary>
        public int PaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaidAmount { get; set; }
        public string MethodName { get; set; }
        public string Notes { get; set; }
    }
}

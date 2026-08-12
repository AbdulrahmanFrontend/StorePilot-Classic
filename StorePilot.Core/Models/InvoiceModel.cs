using DevToolkit.Core.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Models
{
    public class InvoiceModel
    {
        public int InvoiceID { get; set; } = 0;

        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        [Required("مطلوب إدخال حالة الفاتورة")]
        public string InvoiceStatus { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; } = 0;

        public decimal PaidAmount { get; set; } = 0;

        public decimal RemainingAmount => TotalAmount - PaidAmount;

        public int? TransactionID { get; set; } = null;
    }
}

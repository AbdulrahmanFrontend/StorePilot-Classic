using DevToolkit.Core.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Models
{
    public class PaymentModel
    {
        public int PaymentID { get; set; } = 0;

        public int InvoiceID { get; set; } = 0;

        public int MethodID { get; set; } = 0;

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Range(0.01, 999999, "يجب إدخال مبلغ أكبر من صفر وأصغر من أو يساوي 999999")]
        public decimal PaidAmount { get; set; } = 0;

        public bool Cancelled { get; set; } = false;

        [MaxLength(500, "يجب ألا يتجاوز عدد حروف الملاحظات 500 حرف")]
        public string Notes { get; set; } = string.Empty;

        public int? TransactionID { get; set; } = null;
    }
}

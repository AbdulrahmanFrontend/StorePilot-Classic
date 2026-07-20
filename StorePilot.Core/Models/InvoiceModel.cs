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

        [Range(0.01, 999999, "يجب أن يكون المبلغ الإجمالي أكبر من الصفر وأصغر من أو يساوي 999999")]
        public decimal TotalAmount { get; set; } = 0;

        [Range(0, 999999, "يجب أن يكون المبلغ الإجمالي أكبر من أو يساوي الصفر وأصغر من أو يساوي 999999")]
        public decimal PaidAmount { get; set; } = 0;

        public decimal RemainingAmount => TotalAmount - PaidAmount;

        public bool Cancelled { get; set; } = false;

        [MaxLength(500, "يجب ألا يتجاوز عدد حروف الملاحظات ال 500 حرف")]
        public string Notes { get; set; } = string.Empty;

        public int? TransactionID { get; set; } = null;
    }
}

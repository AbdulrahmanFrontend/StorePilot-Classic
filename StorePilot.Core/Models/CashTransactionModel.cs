using DevToolkit.Core.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Models
{
    public class CashTransactionModel
    {
        public int TransactionID { get; set; } = 0;

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public string TransactionType { get; set; } = string.Empty;

        [Range(0.01, 999999, "يجب أن يكون المبلغ المدفوع أكبر من الصفر وأصغر من أو يساوي 999999")]
        public decimal PaidAmount { get; set; } = 0;

        [Required("مطلوب إدخال توصيف الحركة")]
        [MaxLength(100, "يجب ألا يتجاوز توصيف الحركة ال 100 حرف")]
        public string Description { get; set; } = string.Empty;

        public bool Cancelled { get; set; } = false;

        [MaxLength(500, "يجب ألا يتجاوز توصيف الحركة ال 500 حرف")]
        public string Notes { get; set; } = string.Empty;
    }
}

using DevToolkit.Core.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Models
{
    public class SaleReturnModel
    {
        public int ReturnID { get; set; } = 0;

        public int SaleInvoiceID { get; set; } = 0;

        public DateTime ReturnDate { get; set; } = DateTime.Now;

        [Range(0.01, 999999, "يجب أن يكون صافي المرتجع أكبر من الصفر وأصغر من أو يساوي 999999")]
        public decimal TotalReturnAmount { get; set; }

        public bool Cancelled { get; set; } = false;

        public int? TransactionID { get; set; } = null;

        [MaxLength(500, "يجب ألا يتجاوز طول الملاحظات ال 500 حرف")]
        public string Notes { get; set; } = string.Empty;
    }
}

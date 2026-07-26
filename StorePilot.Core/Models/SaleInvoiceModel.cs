using DevToolkit.Core.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Models
{
    public class SaleInvoiceModel : InvoiceModel
    {
        public int SaleInvoiceID { get; set; } = 0;

        public int? CustomerID { get; set; } = null;

        public bool Cancelled { get; set; } = false;

        [MaxLength(500, "يجب ألا يتجاوز طول الملاحظات ال 500 حرف")]
        public string Notes { get; set; } = string.Empty;
    }
}

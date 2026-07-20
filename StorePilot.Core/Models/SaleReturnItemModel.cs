using DevToolkit.Core.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Models
{
    public class SaleReturnItemModel
    {
        public int ReturnItemID { get; set; } = 0;

        public int ProductID { get; set; } = 0;

        public int ReturnID { get; set; } = 0;

        [Range(0.01, 999999, "مطلوب إدخال كمية أكبر من صفر وأصغر من أو يساوي 999999")]
        public decimal Quantity { get; set; } = 0;

        [Range(0.01, 999999, "مطلوب إدخال سعر الوحدة أكبر من صفر وأصغر من أو يساوي 999999")]
        public decimal UnitPrice { get; set; } = 0;

        public decimal TotalPrice => Quantity * UnitPrice;
    }
}

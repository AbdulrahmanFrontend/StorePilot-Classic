using DevToolkit.Core.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; } = 0;

        [Required("مطلوب إدخال اسم الصنف")]
        [MaxLength(100, "يجب ألا يتجاوز طول اسم الصنف ال 100 حرف")]
        public string ProductName { get; set; } = string.Empty;

        [MaxLength(50, "يجب ألا يتجاوز طول الباركود ال 50حرف")]
        public string BarCode { get; set; } = string.Empty;

        public int UnitID { get; set; } = 0;

        public int GroupID { get; set; } = 0;

        [Range(0.01, 999999, "يجب أن يكون سعر الشراء أكبر من الصفر وأصغر من أو يساوي 999999")]
        public decimal PurchasePrice { get; set; } = 0;

        [Range(0.01, 999999, "يجب أن يكون سعر البيع أكبر من الصفر وأصغر من أو يساوي 999999")]
        public decimal SalePrice { get; set; } = 0;

        public decimal Quantity { get; set; } = 0;

        [Range(0, 999999, "يجب أن يكون الحد الأدنى أكبر من أو يساوي الصفر وأصغر من أو يساوي 999999")]
        public decimal MinQuantity { get; set; } = 0;

        public bool Active { get; set; } = true;

        [MaxLength(500, "يجب ألا يتجاوز طول الملاحظات ال 500 حرف")]
        public string Notes { get; set; } = string.Empty;
    }
}

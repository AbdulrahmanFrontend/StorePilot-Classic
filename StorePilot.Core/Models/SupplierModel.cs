using DevToolkit.Core.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Models
{
    public class SupplierModel : PersonModel
    {
        public int SupplierID { get; set; } = 0;

        public bool Active { get; set; } = true;

        [MaxLength(500, "يجب ألا يتجاوز طول الملاحظات ال 500 حرف")]
        public string Notes { get; set; } = string.Empty;
    }
}

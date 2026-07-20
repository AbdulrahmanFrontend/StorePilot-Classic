using DevToolkit.Core.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Models
{
    public class PersonModel
    {
        public int PersonID { get; set; } = 0;

        [Required("مطلوب إدخال الإسم")]
        [MaxLength(50, "يجب ألا يتجاوز طول الإسم ال 50 حرفا")]
        public string Name { get; set; } = string.Empty;

        [Required("مطلوب إدخال رقم الهاتف")]
        [PhoneNo("رقم هاتف غير صالح")]
        public string Phone { get; set; } = string.Empty;

        [MaxLength(50, "يجب ألا يتجاوز طول العنوان ال 50 حرف")]
        public string Address { get; set; } = string.Empty;
    }
}

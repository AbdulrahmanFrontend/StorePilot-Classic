using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Models
{
    public class PaymentMethodModel
    {
        public int MethodID { get; set; } = 0;

        public string MethodName { get; set; } = string.Empty;
    }
}

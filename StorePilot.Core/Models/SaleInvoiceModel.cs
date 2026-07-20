using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Models
{
    public class SaleInvoiceModel
    {
        public int SaleInvoiceID { get; set; } = 0;

        public int? CustomerID { get; set; } = null;
    }
}

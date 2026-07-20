using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Models
{
    public class PurchaseInvoiceModel : InvoiceModel
    {
        public int PurchaseInvoiceID { get; set; } = 0;

        public int? SupplierID { get; set; } = null;
    }
}

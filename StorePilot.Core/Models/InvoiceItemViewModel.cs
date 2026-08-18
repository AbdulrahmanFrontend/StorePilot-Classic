using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Models
{
    public class InvoiceItemViewModel
    {
        public int ProductID { get; set; } = 0;
        public string ProductName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public string GroupName { get; set; } = string.Empty;
        public decimal Quantity { get; set; } = 0;
        public decimal UnitPrice { get; set; } = 0;
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Printing
{
    /// <summary>
    /// One printable line inside an invoice / return items table.
    /// Deliberately does NOT include BarCode or ProductID — the client
    /// never uses barcodes and doesn't care about internal product IDs.
    /// </summary>
    public class PrintableLineItem
    {
        public string GroupName { get; set; }
        public string UnitName { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        /// <summary>Computed, never stored — always Quantity * UnitPrice.</summary>
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}

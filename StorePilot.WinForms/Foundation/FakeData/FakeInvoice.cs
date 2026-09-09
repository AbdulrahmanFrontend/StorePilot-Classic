using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Foundation.FakeData
{
    public sealed class FakeInvoice
    {
        public int Id { get; set; }
        public string Number { get; set; } = "";
        public DateTime Date { get; set; }
        public string Party { get; set; } = "";
        public decimal Total { get; set; }
        public string Status { get; set; } = "مكتملة";
    }
}

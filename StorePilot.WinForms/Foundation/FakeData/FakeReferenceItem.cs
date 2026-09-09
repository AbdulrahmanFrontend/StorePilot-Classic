using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Foundation.FakeData
{
    public sealed class FakeReferenceItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool Active { get; set; } = true;
    }
}

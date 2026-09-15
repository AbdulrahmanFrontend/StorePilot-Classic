using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Dashboard;

public sealed class SalesPoint
{
    public string Label { get; set; } = string.Empty;
    public decimal Value { get; set; }
}

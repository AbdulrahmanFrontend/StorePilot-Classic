using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.ViewModels;

public sealed class LowStockItem
{
    public string? ProductName { get; set; }
    public int CurrentQuantity { get; set; }
    public int MinimumQuantity { get; set; }
}

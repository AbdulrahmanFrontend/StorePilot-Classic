using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Foundation.Models;

public sealed record DemoProduct(
    int Id, 
    string Code,
    string Name,
    string Group, 
    string Unit, 
    decimal Quantity,
    decimal MinQuantity, 
    decimal SalePrice,
    bool Active);
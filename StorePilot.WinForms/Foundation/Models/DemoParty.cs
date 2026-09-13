using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Foundation.Models;

public sealed record DemoParty(
    int Id, 
    string Name,
    string Phone,
    string Address, 
    decimal Total,
    decimal Paid, 
    decimal Balance, 
    bool Active);
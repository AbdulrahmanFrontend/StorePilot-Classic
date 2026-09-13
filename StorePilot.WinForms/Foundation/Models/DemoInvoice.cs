using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Foundation.Models;

public sealed record DemoInvoice(
    string Number, 
    DateTime Date,
    string Party, 
    decimal Total,
    string Status);
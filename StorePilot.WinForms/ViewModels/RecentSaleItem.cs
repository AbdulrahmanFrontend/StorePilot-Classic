using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.ViewModels;

public sealed class RecentSaleItem
{
    public string? InvoiceNumber { get; set; }
    public string? CustomerName { get; set; }
    public string? Total { get; set; }
    public string? PaymentStatus { get; set; }
    public DateTime Date { get; set; }
}

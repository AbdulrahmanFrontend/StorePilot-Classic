using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Dashboard;

public sealed class RecentActivityItem
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;
}

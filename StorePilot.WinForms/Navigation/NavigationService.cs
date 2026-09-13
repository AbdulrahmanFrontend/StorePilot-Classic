using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StorePilot.WinForms.Navigation;

/// <summary>
/// مسؤول عن تغيير الصفحة داخل ContentHost.
/// لا يعرف تفاصيل قاعدة البيانات؛ دوره فقط إدارة التنقل.
/// </summary>
public sealed class NavigationService
{
    private readonly Control _host;
    private readonly Dictionary<string, UserControl> _pages = new();
    public string? CurrentKey { get; private set; }
    public NavigationService(Control host) => _host = host;
    public void Show(NavigationItem item) 
    { 
        if (!_pages.TryGetValue(item.Key, out var page))
        {
            page = item.CreatePage(); 
            page.Dock = DockStyle.Fill;
            _pages[item.Key] = page; 
        } 
        
        foreach (Control c in _host.Controls) 
            c.Visible = false; 

        if (!_host.Controls.Contains(page))
            _host.Controls.Add(page); 

        page.Visible = true; 

        page.BringToFront(); 
        CurrentKey = item.Key; 
    }
}

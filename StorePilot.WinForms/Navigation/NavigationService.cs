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
    public NavigationService(Control host) => _host = host;
    public void Show(NavigationItem item) 
    { 
        _host.Controls.Clear();
        UserControl page = item.CreatePage(); 
        page.Dock = DockStyle.Fill;
        _host.Controls.Add(page);
    }
}

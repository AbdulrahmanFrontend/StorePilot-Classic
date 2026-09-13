using System;
using System.Windows.Forms;

namespace StorePilot.WinForms.Navigation;

/// <summary>
/// تعريف بسيط لعنصر في القائمة الجانبية.
/// لاحقاً يمكن إضافة PermissionKey و Icon وغيرها.
/// </summary>
public sealed record NavigationItem(
    string Key, 
    string Text, 
    Func<UserControl> CreatePage);
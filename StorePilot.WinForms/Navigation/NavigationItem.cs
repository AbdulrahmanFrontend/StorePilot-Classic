using System;
using System.Windows.Forms;

namespace StorePilot.WinForms.Navigation
{
    /// <summary>
    /// تعريف بسيط لعنصر في القائمة الجانبية.
    /// لاحقاً يمكن إضافة PermissionKey و Icon وغيرها.
    /// </summary>
    public sealed class NavigationItem
    {
        public string Key { get; }
        public string Text { get; }
        public Func<UserControl> CreatePage { get; }

        public NavigationItem(string key, string text, Func<UserControl> createPage)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Text = text ?? throw new ArgumentNullException(nameof(text));
            CreatePage = createPage ?? throw new ArgumentNullException(nameof(createPage));
        }
    }
}

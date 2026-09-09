using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StorePilot.WinForms.Navigation
{
    /// <summary>
    /// مسؤول عن تغيير الصفحة داخل ContentHost.
    /// لا يعرف تفاصيل قاعدة البيانات؛ دوره فقط إدارة التنقل.
    /// </summary>
    public sealed class NavigationService
    {
        private readonly Control _host;
        private readonly Dictionary<string, UserControl> _cache = new();

        public string? CurrentKey { get; private set; }

        public NavigationService(Control host)
        {
            _host = host ?? throw new ArgumentNullException(nameof(host));
        }

        public void RegisterAndShow(NavigationItem item)
        {
            if (!_cache.ContainsKey(item.Key))
                _cache[item.Key] = item.CreatePage();

            Show(item.Key);
        }

        public void Show(string key)
        {
            if (!_cache.TryGetValue(key, out var page))
                throw new InvalidOperationException(
                    "Navigation item is not registered: " + key);

            _host.SuspendLayout();
            try
            {
                foreach (Control control in _host.Controls)
                    control.Visible = false;

                page.Dock = DockStyle.Fill;

                if (!_host.Controls.Contains(page))
                    _host.Controls.Add(page);

                page.Visible = true;
                page.BringToFront();
                CurrentKey = key;
            }
            finally
            {
                _host.ResumeLayout(true);
            }
        }
    }
}

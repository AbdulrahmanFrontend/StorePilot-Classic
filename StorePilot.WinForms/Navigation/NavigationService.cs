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
        private readonly Panel _host;
        private readonly Dictionary<string, UserControl> _cache =
            new Dictionary<string, UserControl>();

        public string CurrentKey { get; private set; }

        public NavigationService(Panel host)
        {
            _host = host ?? throw new ArgumentNullException(nameof(host));
        }

        public void RegisterAndShow(NavigationItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (!_cache.ContainsKey(item.Key))
                _cache[item.Key] = item.CreatePage();

            Show(item.Key);
        }

        public void Show(string key)
        {
            if (!_cache.TryGetValue(key, out UserControl page))
                throw new InvalidOperationException(
                    "Navigation item is not registered: " + key);

            _host.SuspendLayout();

            try
            {
                foreach (Control control in _host.Controls)
                    control.Visible = false;

                page.Dock = DockStyle.Fill;
                page.Visible = true;

                if (!_host.Controls.Contains(page))
                    _host.Controls.Add(page);

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

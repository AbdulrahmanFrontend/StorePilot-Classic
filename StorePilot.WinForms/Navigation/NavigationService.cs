using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StorePilot.WinForms.Navigation;

public sealed class NavigationService
{
    private readonly Control _contentHost;
    private readonly Dictionary<string, UserControl> _pages = new();

    private string? _currentPageKey;

    public NavigationService(Control contentHost)
    {
        _contentHost = contentHost;
    }

    public void Navigate<TPage>(
        string key,
        Func<TPage> factory)
        where TPage : UserControl
    {
        if (!_pages.TryGetValue(key, out var page))
        {
            page = factory();

            page.Dock = DockStyle.Fill;

            _pages[key] = page;
        }

        if (_currentPageKey == key)
            return;

        _contentHost.SuspendLayout();

        try
        {
            _contentHost.Controls.Clear();
            _contentHost.Controls.Add(page);

            page.BringToFront();

            _currentPageKey = key;
        }
        finally
        {
            _contentHost.ResumeLayout();
        }
    }

    public void Remove(string key)
    {
        if (_pages.TryGetValue(key, out var page))
        {
            _pages.Remove(key);
            page.Dispose();
        }
    }

    public void Clear()
    {
        foreach (var page in _pages.Values)
            page.Dispose();

        _pages.Clear();
        _contentHost.Controls.Clear();
        _currentPageKey = null;
    }
}
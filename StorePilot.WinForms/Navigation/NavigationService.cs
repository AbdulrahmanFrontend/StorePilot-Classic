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

    public string? CurrentPageKey => _currentPageKey;

    public void Navigate<TPage>(
        string key,
        Func<TPage> factory)
        where TPage : UserControl
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException(
                "مفتاح الصفحة غير صالح.",
                nameof(key));

        ArgumentNullException.ThrowIfNull(factory);

        if (!_pages.TryGetValue(key, out UserControl? page))
        {
            page = factory();

            page.Dock = DockStyle.Fill;

            _pages.Add(key, page);
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

    public bool Contains(string key)
    {
        return _pages.ContainsKey(key);
    }

    public void Remove(string key)
    {
        if (!_pages.TryGetValue(key, out UserControl? page))
            return;

        _pages.Remove(key);

        if (_currentPageKey == key)
            _currentPageKey = null;

        page.Dispose();
    }

    public void Clear()
    {
        foreach (UserControl page in _pages.Values)
            page.Dispose();

        _pages.Clear();

        _contentHost.Controls.Clear();

        _currentPageKey = null;
    }
}

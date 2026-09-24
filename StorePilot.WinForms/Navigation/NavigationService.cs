using StorePilot.WinForms.Pages;
using System.Windows.Forms;

namespace StorePilot.WinForms.Navigation;

public sealed class NavigationService
{
    private readonly Control _contentHost;
    private readonly IPageFactory _pageFactory;

    private readonly Dictionary<PageKey, UserControl> _pages = new();

    private PageKey _currentPageKey = PageKey.Unknown;

    public NavigationService(
        Control contentHost,
        IPageFactory pageFactory)
    {
        _contentHost = contentHost;
        _pageFactory = pageFactory;
    }

    public PageKey CurrentPageKey => _currentPageKey;

    public void Navigate<TPage>(PageKey key) where TPage : UserControl
    {
        if (key == PageKey.Unknown)
            throw new ArgumentException(
                "Unknown page key is not allowed.",
                nameof(key));

        if (!_pages.TryGetValue(key, out var page))
        {
            page = _pageFactory.Create<TPage>();

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

    public bool Contains(PageKey key)
    {
        return _pages.ContainsKey(key);
    }

    public UserControl? GetCurrentPage()
    {
        _pages.TryGetValue(_currentPageKey, out UserControl? page);
        return page;
    }

    public void Remove(PageKey key)
    {
        if (!_pages.TryGetValue(key, out UserControl? page))
            return;

        _pages.Remove(key);

        if (_currentPageKey == key)
            _currentPageKey = PageKey.Unknown;

        page.Dispose();
    }

    public void Clear()
    {
        foreach (UserControl page in _pages.Values)
            page.Dispose();

        _pages.Clear();

        _contentHost.Controls.Clear();

        _currentPageKey = PageKey.Unknown;
    }
}

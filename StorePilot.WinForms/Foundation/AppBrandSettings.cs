using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.Foundation;

public sealed class AppBrandSettings
{
    public string StoreName { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public ThemeMode Theme { get; set; }

    public string? LogoFileName { get; set; }

    public bool IsConfigured { get; set; }
}
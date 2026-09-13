using StorePilot.WinForms.Theme;
using System;

namespace StorePilot.WinForms.Foundation;

public sealed class AppBrandSettings
{
    public string ShopName { get; set; } = "";
    public string UserDisplayName { get; set; } = "";
    public string LogoPath { get; set; } = "";
    public ThemeMode Theme { get; set; } = ThemeMode.Light;

    public bool IsConfigured => 
        !string.IsNullOrWhiteSpace(ShopName) 
        && !string.IsNullOrWhiteSpace(UserDisplayName);
}
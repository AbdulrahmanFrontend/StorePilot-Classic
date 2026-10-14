using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.ViewModels;

public sealed class SettingsViewModel
{
    public string? StoreName { get; set; }
    public string? UserName { get; set; }

    public ThemeMode Theme { get; set; }

    public Image? Logo { get; set; }

    public string? LogoFileName { get; set; }

    public string? LastBackupDirectory { get; set; }

    public string? LastBackupFileName { get; set; }
}
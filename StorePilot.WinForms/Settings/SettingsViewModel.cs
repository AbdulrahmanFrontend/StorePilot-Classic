using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.Settings;

public sealed class SettingsViewModel
{
    public string StoreName { get; set; } = "StorePilot";

    public string StorePhone { get; set; } = string.Empty;

    public string StoreAddress { get; set; } = string.Empty;

    public ThemeMode Theme { get; set; } = ThemeMode.Light;

    public bool EnableAutoBackup { get; set; } = true;

    public int BackupIntervalDays { get; set; } = 1;
}

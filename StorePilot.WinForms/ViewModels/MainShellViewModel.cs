using StorePilot.WinForms.Foundation;

namespace StorePilot.WinForms.ViewModels;

public sealed class MainShellViewModel
{
    private readonly AppBrandSettingsStore _settingsStore;

    public MainShellViewModel(AppBrandSettingsStore settingsStore)
    {
        _settingsStore = settingsStore;

        Reload();
    }

    public AppBrandSettings Settings { get; private set; } = new();

    public string StoreName =>
        string.IsNullOrWhiteSpace(Settings.StoreName)
            ? "StorePilot"
            : Settings.StoreName;

    public string UserName =>
        string.IsNullOrWhiteSpace(Settings.UserName)
            ? "المستخدم"
            : Settings.UserName;

    public string? LogoPath =>
        _settingsStore.GetLogoPath();

    public void Reload() => Settings = _settingsStore.Load();
}

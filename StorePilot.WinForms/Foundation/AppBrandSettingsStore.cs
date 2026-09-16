using System.Text.Json;
using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.Foundation;

public sealed class AppBrandSettingsStore
{
    private static readonly string[] SupportedExtensions =
    {
        ".png",
        ".jpg",
        ".jpeg",
        ".bmp"
    };

    private readonly string _rootPath;
    private readonly string _settingsPath;
    private readonly string _brandingDirectory;

    public string RootPath => _rootPath;

    public string SettingsPath => _settingsPath;

    public string BrandingDirectory => _brandingDirectory;

    public AppBrandSettingsStore()
    {
        _rootPath = Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "StorePilot");

        var settingsDirectory = Path.Combine(_rootPath, "Settings");

        Directory.CreateDirectory(settingsDirectory);

        _settingsPath = Path.Combine(settingsDirectory,
            "app-settings.json");

        _brandingDirectory = Path.Combine(
            _rootPath,
            "Branding");

        Directory.CreateDirectory(_rootPath);
        Directory.CreateDirectory(_brandingDirectory);
    }

    public AppBrandSettings Load()
    {
        if (!File.Exists(_settingsPath))
            return new AppBrandSettings();

        try
        {
            var json = File.ReadAllText(_settingsPath);

            return JsonSerializer.Deserialize<AppBrandSettings>(json)
                   ?? new AppBrandSettings();
        }
        catch
        {
            return new AppBrandSettings();
        }
    }

    public void Save(AppBrandSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        Directory.CreateDirectory(_rootPath);

        string temporaryPath = _settingsPath + ".tmp";

        var json = JsonSerializer.Serialize(
            settings,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(
            temporaryPath,
            json);

        File.Move(
            temporaryPath,
            _settingsPath,
            true);
    }

    public string? GetLogoPath()
    {
        if (!Directory.Exists(_brandingDirectory))
            return null;

        return Directory
            .GetFiles(_brandingDirectory)
            .FirstOrDefault(IsSupportedImage);
    }

    public void ReplaceLogo(string sourcePath)
    {
        if (string.IsNullOrWhiteSpace(sourcePath))
            throw new ArgumentException(
                "مسار الشعار غير صالح.",
                nameof(sourcePath));

        if (!File.Exists(sourcePath))
            throw new FileNotFoundException(
                "ملف الشعار غير موجود.",
                sourcePath);

        if (!IsSupportedImage(sourcePath))
            throw new InvalidOperationException(
                "صيغة الشعار غير مدعومة. استخدم PNG أو JPG أو BMP.");

        DeleteLogo();

        string extension = Path
            .GetExtension(sourcePath)
            .ToLowerInvariant();

        string destinationPath = Path.Combine(
            _brandingDirectory,
            "logo" + extension);

        File.Copy(
            sourcePath,
            destinationPath,
            true);

        var settings = Load();

        settings.LogoFileName = "logo" + extension;

        Save(settings);
    }

    public void DeleteLogo()
    {
        if (!Directory.Exists(_brandingDirectory))
            return;

        foreach (string file in Directory.GetFiles(_brandingDirectory))
        {
            if (IsSupportedImage(file))
                File.Delete(file);
        }

        var settings = Load();

        settings.LogoFileName = null;

        Save(settings);
    }

    public string GetDefaultDatabasePath()
    {
        return Path.Combine(_rootPath,
            "Data",
            "StorePilot.db");
    }

    public string GetDefaultBackupDirectory()
    {
        string directory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "StorePilot",
            "Backups");

        Directory.CreateDirectory(directory);

        return directory;
    }

    private static bool IsSupportedImage(string path)
    {
        return SupportedExtensions.Contains(
            Path.GetExtension(path).ToLowerInvariant());
    }
}

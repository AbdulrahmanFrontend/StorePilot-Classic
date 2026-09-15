using System.Text.Json;

namespace StorePilot.WinForms.Foundation;

public sealed class AppBrandSettingsStore
{
    private readonly string _rootPath;
    private readonly string _settingsPath;
    private readonly string _brandingDirectory;

    private static readonly string[] SupportedExtensions =
    {
        ".png",
        ".jpg",
        ".jpeg",
        ".bmp"
    };

    public string BrandingDirectory => _brandingDirectory;

    public AppBrandSettingsStore()
    {
        _rootPath = Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "StorePilot");

        _settingsPath = Path.Combine(
            _rootPath,
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
        Directory.CreateDirectory(_rootPath);

        var temporaryPath = _settingsPath + ".tmp";

        var json = JsonSerializer.Serialize(
            settings,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(temporaryPath, json);

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
        if (!File.Exists(sourcePath))
            throw new FileNotFoundException(
                "ملف الشعار غير موجود.",
                sourcePath);

        if (!IsSupportedImage(sourcePath))
            throw new InvalidOperationException(
                "صيغة الشعار غير مدعومة. استخدم PNG أو JPG أو BMP.");

        DeleteLogo();

        var extension = Path
            .GetExtension(sourcePath)
            .ToLowerInvariant();

        var destinationPath = Path.Combine(
            _brandingDirectory,
            "logo" + extension);

        File.Copy(
            sourcePath,
            destinationPath,
            true);
    }

    public void DeleteLogo()
    {
        if (!Directory.Exists(_brandingDirectory))
            return;

        foreach (var file in Directory.GetFiles(_brandingDirectory))
        {
            if (IsSupportedImage(file))
                File.Delete(file);
        }
    }

    private static bool IsSupportedImage(string path)
    {
        return SupportedExtensions.Contains(
            Path.GetExtension(path).ToLowerInvariant());
    }
}
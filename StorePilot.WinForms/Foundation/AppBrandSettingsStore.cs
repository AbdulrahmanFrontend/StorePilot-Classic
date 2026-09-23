using System.Text.Json;

namespace StorePilot.WinForms.Foundation;

public sealed class AppBrandSettingsStore
{
    private readonly string _settingsFilePath;
    private readonly string _brandingDirectory;

    public AppBrandSettingsStore(
        string settingsFilePath,
        string brandingDirectory)
    {
        _settingsFilePath = settingsFilePath;
        _brandingDirectory = brandingDirectory;

        Directory.CreateDirectory(
            Path.GetDirectoryName(_settingsFilePath)!);

        Directory.CreateDirectory(
            _brandingDirectory);
    }

    public string GetLogoPath()
    {
        var settings = Load();

        if (string.IsNullOrWhiteSpace(settings.LogoFileName))
            return string.Empty;

        return Path.Combine(
            _brandingDirectory,
            settings.LogoFileName);
    }

    public AppBrandSettings Load()
    {
        if (!File.Exists(_settingsFilePath))
            return new AppBrandSettings();

        try
        {
            var json =
                File.ReadAllText(_settingsFilePath);

            var settings =
                JsonSerializer.Deserialize<AppBrandSettings>(
                    json);

            return settings ?? new AppBrandSettings();
        }
        catch
        {
            return new AppBrandSettings();
        }
    }

    public void Save(AppBrandSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        Directory.CreateDirectory(
            Path.GetDirectoryName(_settingsFilePath)!);

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var json =
            JsonSerializer.Serialize(
                settings,
                options);

        File.WriteAllText(
            _settingsFilePath,
            json);
    }

    public void SaveLogo(string? sourceFilePath)
    {
        if (string.IsNullOrWhiteSpace(sourceFilePath))
        {
            throw new ArgumentException(
                "Logo source path is required.",
                nameof(sourceFilePath));
        }

        if (!File.Exists(sourceFilePath))
        {
            throw new FileNotFoundException(
                "Logo file was not found.",
                sourceFilePath);
        }

        Directory.CreateDirectory(
            _brandingDirectory);

        var extension =
            Path.GetExtension(sourceFilePath)
                .ToLowerInvariant();

        if (string.IsNullOrWhiteSpace(extension))
            extension = ".png";

        var fileName =
            "logo" + extension;

        var destinationPath =
            Path.Combine(
                _brandingDirectory,
                fileName);

        File.Copy(
            sourceFilePath,
            destinationPath,
            true);

        var settings = Load();

        settings.LogoFileName = fileName;

        Save(settings);
    }

    public void RemoveLogo()
    {
        var settings = Load();

        if (!string.IsNullOrWhiteSpace(
                settings.LogoFileName))
        {
            var logoPath =
                Path.Combine(
                    _brandingDirectory,
                    settings.LogoFileName);

            if (File.Exists(logoPath))
                File.Delete(logoPath);
        }

        settings.LogoFileName = null;

        Save(settings);
    }
}
using System.Text.Json;
using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.Foundation;

public sealed class AppBrandSettingsStore
{
    private readonly string _rootPath;
    private readonly string _settingsFilePath;
    private readonly string _databasePath;
    private readonly string _brandingDirectory;
    private readonly string _backupDirectory;

    public AppBrandSettingsStore()
    {
        _rootPath = Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "StorePilot");

        _settingsFilePath = Path.Combine(
            _rootPath,
            "Settings",
            "app-settings.json");

        _databasePath = Path.Combine(
            _rootPath,
            "Data",
            "StorePilot.db");

        _brandingDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Branding");

        _backupDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Backups");

        Directory.CreateDirectory(_rootPath);
        Directory.CreateDirectory(Path.GetDirectoryName(_databasePath)!);
        Directory.CreateDirectory(_brandingDirectory);
        Directory.CreateDirectory(_backupDirectory);
    }

    public string RootPath => _rootPath;

    public string GetDatabasePath()
    {
        return _databasePath;
    }

    public string GetDefaultBackupDirectory()
    {
        Directory.CreateDirectory(_backupDirectory);

        return _backupDirectory;
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
            var json = File.ReadAllText(_settingsFilePath);

            var settings =
                JsonSerializer.Deserialize<AppBrandSettings>(json);

            return settings ?? new AppBrandSettings();
        }
        catch
        {
            return new AppBrandSettings();
        }
    }

    public void Save(AppBrandSettings settings)
    {
        if (settings == null)
            throw new ArgumentNullException(nameof(settings));

        Directory.CreateDirectory(_rootPath);

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var json = JsonSerializer.Serialize(
            settings,
            options);

        File.WriteAllText(
            _settingsFilePath,
            json);
    }

    public void SaveLogo(string sourceFilePath)
    {
        if (string.IsNullOrWhiteSpace(sourceFilePath))
            throw new ArgumentException(
                "Logo source path is required.",
                nameof(sourceFilePath));

        if (!File.Exists(sourceFilePath))
            throw new FileNotFoundException(
                "Logo file was not found.",
                sourceFilePath);

        Directory.CreateDirectory(_brandingDirectory);

        var extension =
            Path.GetExtension(sourceFilePath)
            .ToLowerInvariant();

        if (string.IsNullOrWhiteSpace(extension))
            extension = ".png";

        var fileName = "logo" + extension;

        var destinationPath = Path.Combine(
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

        if (!string.IsNullOrWhiteSpace(settings.LogoFileName))
        {
            var logoPath = Path.Combine(
                _brandingDirectory,
                settings.LogoFileName);

            if (File.Exists(logoPath))
                File.Delete(logoPath);
        }

        settings.LogoFileName = null;

        Save(settings);
    }
}

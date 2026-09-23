namespace StorePilot.Infrastructure.Storage;

public sealed class StorePilotPaths
{
    public StorePilotPaths()
    {
        RootDirectory = Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "StorePilot");

        SettingsDirectory =
            Path.Combine(
                RootDirectory,
                "Settings");

        DataDirectory =
            Path.Combine(
                RootDirectory,
                "Data");

        BrandingDirectory =
            Path.Combine(
                RootDirectory,
                "Branding");

        BackupDirectory =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments),
                "StorePilot",
                "Backups");

        SettingsFilePath =
            Path.Combine(
                SettingsDirectory,
                "app-settings.json");

        DatabaseFilePath =
            Path.Combine(
                DataDirectory,
                "StorePilot.db");
    }

    public string RootDirectory { get; }

    public string SettingsDirectory { get; }

    public string DataDirectory { get; }

    public string BrandingDirectory { get; }

    public string BackupDirectory { get; }

    public string SettingsFilePath { get; }

    public string DatabaseFilePath { get; }

    public void EnsureDirectories()
    {
        Directory.CreateDirectory(RootDirectory);
        Directory.CreateDirectory(SettingsDirectory);
        Directory.CreateDirectory(DataDirectory);
        Directory.CreateDirectory(BrandingDirectory);
        Directory.CreateDirectory(BackupDirectory);
    }
}

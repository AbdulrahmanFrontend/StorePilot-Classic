using System;
using System.IO;
using System.Xml.Serialization;

namespace StorePilot.WinForms.Foundation
{
    /// <summary>
    /// Persists the small amount of branding information needed by the shell.
    ///
    /// Why XML here?
    /// - Works directly with .NET Framework 4.8.
    /// - No database is required just to start the application.
    /// - Easy to replace later with a database-backed settings service.
    /// </summary>
    public sealed class AppBrandSettingsStore
    {
        private readonly string _rootDirectory;
        private readonly string _settingsFile;
        private readonly string _brandingDirectory;

        public AppBrandSettingsStore()
        {
            _rootDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "StorePilot");

            _brandingDirectory = Path.Combine(_rootDirectory, "Branding");
            _settingsFile = Path.Combine(_brandingDirectory, "brand-settings.xml");

            Directory.CreateDirectory(_rootDirectory);
            Directory.CreateDirectory(_brandingDirectory);
        }

        public string BrandingDirectory => _brandingDirectory;

        public AppBrandSettings Load()
        {
            if (!File.Exists(_settingsFile))
                return new AppBrandSettings();

            try
            {
                var serializer = new XmlSerializer(typeof(AppBrandSettings));

                using (var stream = File.OpenRead(_settingsFile))
                {
                    return (AppBrandSettings)serializer.Deserialize(stream)
                           ?? new AppBrandSettings();
                }
            }
            catch
            {
                // A broken settings file must not prevent the application from starting.
                // In a production version we can add logging here.
                return new AppBrandSettings();
            }
        }

        public void Save(AppBrandSettings settings)
        {
            Directory.CreateDirectory(_rootDirectory);
            Directory.CreateDirectory(_brandingDirectory);

            var serializer = new XmlSerializer(typeof(AppBrandSettings));

            using (var stream = File.Create(_settingsFile))
            {
                serializer.Serialize(stream, settings);
            }
        }

        /// <summary>
        /// Replaces the current logo with the selected image.
        /// The old stored image is deleted first, so we do not accumulate unused logos.
        /// </summary>
        public string ReplaceLogo(string sourceFilePath)
        {
            if (string.IsNullOrWhiteSpace(sourceFilePath) || !File.Exists(sourceFilePath))
                throw new FileNotFoundException("The selected logo file was not found.", sourceFilePath);

            DeleteStoredLogo();

            var extension = Path.GetExtension(sourceFilePath);
            if (string.IsNullOrWhiteSpace(extension))
                extension = ".png";

            var destination = Path.Combine(_brandingDirectory, "logo" + extension.ToLowerInvariant());

            // Copy instead of storing the original path.
            // This prevents the application from depending on a file outside its own data folder.
            File.Copy(sourceFilePath, destination, true);

            return Path.GetFileName(destination);
        }

        public void DeleteStoredLogo()
        {
            if (!Directory.Exists(_brandingDirectory))
                return;

            foreach (var file in Directory.GetFiles(_brandingDirectory, "logo.*"))
            {
                try
                {
                    File.Delete(file);
                }
                catch
                {
                    // If the file is locked, the caller can continue without crashing.
                    // A later cleanup/logging policy can handle this more explicitly.
                }
            }
        }

        public string? GetLogoPath(string logoFileName)
        {
            if (string.IsNullOrWhiteSpace(logoFileName))
                return null;

            var path = Path.Combine(_brandingDirectory, logoFileName);
            return File.Exists(path) ? path : null;
        }
    }
}

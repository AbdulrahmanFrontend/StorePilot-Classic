using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Helpers
{
    public static class AppPaths
    {
        public static readonly string RootFolder =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Store Pilot");

        public static readonly string DataFolder =
            Path.Combine(RootFolder, "Data");

        public static readonly string BackupFolder =
            Path.Combine(RootFolder, "Backups");

        public static readonly string LogsFolder =
            Path.Combine(RootFolder, "Logs");

        public static readonly string SettingsFolder =
            Path.Combine(RootFolder, "Settings");

        public static readonly string ExportsFolder =
            Path.Combine(RootFolder, "Exports");

        public static readonly string TempFolder =
            Path.Combine(RootFolder, "Temp");

        public static readonly string DatabasePath =
            Path.Combine(DataFolder, "StorePilot.db");

        public static readonly string DatabaseScriptPath =
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Database",
                "Scripts",
                "InitialDatabase.sql");
    }
}

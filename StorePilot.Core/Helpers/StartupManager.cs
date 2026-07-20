using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Helpers
{
    public class StartupManager
    {
        public static void Initialize()
        {
            CreateFolders();
        }

        private static void CreateFolders()
        {
            Directory.CreateDirectory(AppPaths.RootFolder);

            Directory.CreateDirectory(AppPaths.DataFolder);

            Directory.CreateDirectory(AppPaths.BackupFolder);

            Directory.CreateDirectory(AppPaths.LogsFolder);

            Directory.CreateDirectory(AppPaths.SettingsFolder);

            Directory.CreateDirectory(AppPaths.ExportsFolder);

            Directory.CreateDirectory(AppPaths.TempFolder);
        }
    }
}

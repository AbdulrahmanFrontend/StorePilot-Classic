using DevToolkit.Logging.Managers;
using StorePilot.Core.Helpers;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Database
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            if (DatabaseExists())
                return;

            CreateDatabase();
        }

        private static bool DatabaseExists()
            => File.Exists(AppPaths.DatabasePath);

        private static void CreateDatabase()
        {
            DatabaseScriptRunner.Execute();

            LogManager.LogInfo("تم إنشاء قاعدة البيانات لأول مرة.");
        }
    }
}

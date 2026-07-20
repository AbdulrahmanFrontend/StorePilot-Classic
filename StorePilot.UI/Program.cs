using DevToolkit.Data.Core;
using DevToolkit.Logging.Managers;
using DevToolkit.Logging.Providers;
using StorePilot.Core.Database;
using StorePilot.Core.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorePilot.UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StartupManager.Initialize();

            FileLogger.LogFilePath = Path.Combine(
                AppPaths.LogsFolder,
                $"{DateTime.Today:yyyy-MM-dd}.log");

            LogManager.Current = new FileLogger();

            DbManager.Initialize(
                DevToolkit.Data.Core.DbProviderFactory.DbProvider.SQLite);

            DatabaseInitializer.Initialize();

            DataConfiguration.Configure($@"Data Source={AppPaths.DatabasePath};
                Foreign Keys=True;");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

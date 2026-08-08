using DevToolkit.BaseWinForms.Theming;
using DevToolkit.Data.Core;
using DevToolkit.Infrastructure.Startup;
using DevToolkit.Logging.Managers;
using DevToolkit.Logging.Providers;
using StorePilot.UI.Global.Classes;
using DevToolkit.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            ThemeManager.CurrentTheme = Themes.Light;

            ThemeManager.ApplyTheme();

            StartupManager.Initialize(new StartupOptions
            {
                ApplicationName = "StorePilot",
                CompanyName = "DevToolkit",
                EnableFileLogging = true,
            },
            new DatabaseOptions
            {
                CreateIfNotExists = true,
                RunScripts = true,
                DatabaseName = "StorePilotDB",
                Provider = DbProviderFactory.DbProvider.SQLite
            });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSplash());
        }
    }
}

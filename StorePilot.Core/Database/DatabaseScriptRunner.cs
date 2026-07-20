using DevToolkit.Logging.Managers;
using StorePilot.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Core.Database
{
    internal static class DatabaseScriptRunner
    {
        internal static void Execute()
        {
            try
            {
                if (!File.Exists(AppPaths.DatabaseScriptPath))
                {
                    throw new FileNotFoundException(
                        "ملف بناء الداتابيز غير موجود!",
                        AppPaths.DatabaseScriptPath);
                }

                SQLiteConnection.CreateFile(AppPaths.DatabasePath);

                string script =
                    File.ReadAllText(
                        AppPaths.DatabaseScriptPath);

                using (SQLiteConnection connection =
                    new SQLiteConnection(
                        $"Data Source={AppPaths.DatabasePath};Foreign Keys=True;"))
                {
                    connection.Open();

                    using (SQLiteCommand command =
                        new SQLiteCommand(script, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError("فشلت عملية بناء ملف الداتابيز!", ex);

                throw;
            }
        }
    }
}

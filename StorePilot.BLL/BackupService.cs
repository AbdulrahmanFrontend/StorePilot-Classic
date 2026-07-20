using DevToolkit.Core.Results;
using DevToolkit.Data.Core;
using DevToolkit.Logging.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.BLL
{
    public sealed class BackupService
    {
        public static Result<string> CreateBackup(string destinationFile)
        {
            try
            {
                string databaseFile = DataConfiguration.DatabaseFilePath;

                if (!File.Exists(databaseFile))
                    return Result<string>.Failure("ملف الداتابيز غير موجود!");

                string folder = Path.GetDirectoryName(destinationFile);

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                File.Copy(databaseFile, destinationFile, true);

                LogManager.LogInfo("تمت عملية النسخ الاحتياطي بنجاح.");

                return Result<string>.Success(
                    destinationFile,
                    "تمت عملية النسخ الإحتياطي بنجاح.");
            }
            catch (Exception ex)
            {
                LogManager.LogError("فشلت عملية النسخ الإحتياطي!", ex);

                return Result<string>.Failure(
                    "فشلت عملية النسخ الإحتياطي!");
            }
        }
    }
}

using DevToolkit.Infrastructure.Database;
using DevToolkit.Infrastructure.Startup;
using StorePilot.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using DevToolkit.Data.Core;
//using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.Tools
{
    internal class Program
    {
        static async Task Initialize()
        {
            await Task.Run(() => StartupManager.Initialize(new StartupOptions
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
            }));
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Initialize().GetAwaiter().GetResult();

            var result = PurchaseInvoiceService.GetInvoices(1, 1, 1, 1.ToString(), false);

            foreach (DataRow row in result.Data.Rows)
            {
                Console.WriteLine($"{row["PurchaseInvoiceID"]}," +
                    $"{row["InvoiceID"]}, {row["InvoiceDate"]}, " +
                    $"{row["InvoiceStatus"].ToString()}, {row["PaidAmount"]}, " +
                    $"{row["RemainingAmount"]}, {row["SupplierName"].ToString()}, " +
                    $"{row["TotalAmount"]}, {row["CreatedAt"]}, {row["Cancelled"]}");
            }
        }
    }
}

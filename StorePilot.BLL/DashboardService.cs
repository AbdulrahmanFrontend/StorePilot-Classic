using DevToolkit.Core.Results;
using StorePilot.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.BLL
{
    public static class DashboardService
    {
        public static Task<Result<DataSet>> GetDashboardData()
        {
            DataSet dataSet = new DataSet();

            // Get summary data
            Result<DataTable> result = DashboardDAL.GetSummary();
            if (!result.IsSuccess)
                return Task.Run(() => Result<DataSet>.Failure("فشلت عملية الوصول لبيانات البطاقات!"));
            result.Data.TableName = "Summary";
            dataSet.Tables.Add(result.Data);

            // Get chart data
            result = DashboardDAL.GetChartData();
            if (!result.IsSuccess)
                return Task.Run(() => Result<DataSet>.Failure(
                    "فشلت عملية الوصول لبيانات الرسم البياني!"));
            result.Data.TableName = "ChartData";
            dataSet.Tables.Add(result.Data);

            // Get low stock products data
            result = DashboardDAL.GetLowStockProducts();
            if (!result.IsSuccess)
                return Task.Run(() => Result<DataSet>.Failure(
                    "فشلت عملية الوصول لبيانات المنتجات منخفضة المخزون!"));
            result.Data.TableName = "LowStockProducts";
            dataSet.Tables.Add(result.Data); 

            // Get recent sales data
            result = DashboardDAL.GetRecentSales();
            if (!result.IsSuccess)
                return Task.Run(() => Result<DataSet>.Failure(
                    "فشلت عملية الوصول لبيانات المنتجات منخفضة المخزون!"));
            result.Data.TableName = "RecentSales";
            dataSet.Tables.Add(result.Data);

            return Task.Run(() => Result<DataSet>.Success(dataSet));
        }
    }
}

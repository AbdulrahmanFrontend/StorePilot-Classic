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
        public static Result<DataSet> GetDashboardData()
        {
            DataSet dataSet = new DataSet();

            Result<DataTable> result = DashboardDAL.GetSummary();

            if(!result.IsSuccess)
                return Result<DataSet>.Failure("فشلت عملية الوصول لبيانات البطاقات!");

            result.Data.TableName = "Summary";

            dataSet.Tables.Add(result.Data);

            //DataTable salesChartTable = new DataTable("SalesChart");

            //DataTable lowStockTable = new DataTable("LowStockProducts");

            //DataTable recentSalesTable = new DataTable("RecentSales");

            //dataSet.Tables.Add(salesChartTable);
            //dataSet.Tables.Add(lowStockTable);
            //dataSet.Tables.Add(recentSalesTable);

            return Result<DataSet>.Success(dataSet);
        }
    }
}

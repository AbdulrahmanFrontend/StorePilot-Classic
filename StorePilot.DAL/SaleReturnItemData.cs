using DevToolkit.Core.Results;
using DevToolkit.Data.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.DAL
{
    public static class SaleReturnItemData
    {
        public static Result<DataTable> GetSalesReturnItems(int returnId)
        {
            string Query = @"SELECT * FROM view_SalesReturnItemsDetails 
                WHERE ReturnID = @ReturnID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@ReturnID",
                    DbType = DbType.Int32,
                    Value = returnId,
                },
            };

            return DbManager.Current?.GetDataTable(CommandType.Text, Query, Parameters);
        }
    }
}

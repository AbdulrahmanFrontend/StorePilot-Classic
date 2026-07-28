using DevToolkit.Core.Results;
using DevToolkit.Data.Core;
using StorePilot.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.DAL
{
    public static class SaleReturnItemData
    {
        public static Result AddNew(
            IDbConnection con,
            IDbTransaction trans,
            SaleReturnItemModel model)
        {
            string Query = @"INSERT INTO SalesReturnItems
                (
                    ReturnID,
                    ProductID,
                    Quantity,
                    UnitPrice
                )
                VALUES
                (
                    @ReturnID,
                    @ProductID,
                    @Quantity,
                    @UnitPrice
                );

                SELECT LAST_INSERT_ROWID();";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@ReturnID",
                    DbType = DbType.Int64,
                    Value = model.ReturnID,
                },
                new DbParameterInfo
                {
                    Name = "@ProductID",
                    DbType = DbType.Int64,
                    Value = model.ProductID,
                },
                new DbParameterInfo
                {
                    Name = "@Quantity",
                    DbType = DbType.Decimal,
                    Value = model.Quantity,
                },
                new DbParameterInfo
                {
                    Name = "@UnitPrice",
                    DbType = DbType.Decimal,
                    Value = model.UnitPrice,
                },
            };

            Result<int> result = DbManager.Current?.GetScalar<int>(
                con,
                trans,
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
            {
                model.ReturnItemID = result.Data;

                return Result.Success();
            }

            return Result.Failure("فشلت عملية إضافة أصناف المرتجع!");
        }

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

using DevToolkit.Core.Results;
using DevToolkit.Data;
using DevToolkit.Data.Core;
using StorePilot.Core.Models;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.DAL
{
    public static class SaleReturnData
    {
        public static Result<SaleReturnModel> GetByID(int id)
        {
            string Query = @"SELECT * FROM SalesReturns WHERE ReturnID = @ReturnID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@ReturnID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.FirstOrDefault<SaleReturnModel>(
                CommandType.Text,
                Query, 
                Parameters);
        }

        public static Result AddNew(
            IDbConnection con,
            IDbTransaction trans,
            SaleReturnModel model)
        {
            string Query = @"INSERT INTO SalesReturns
                (
                    SaleInvoiceID,
                    ReturnDate,
                    TotalReturnAmount,
                    TransactionID
                )
                VALUES
                (
                    @SaleInvoiceID,
                    @ReturnDate,
                    @TotalReturnAmount,
                    @TransactionID
                );

                SELECT LAST_INSERT_ROWID();";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@SaleInvoiceID",
                    DbType = DbType.Int64,
                    Value = model.SaleInvoiceID,
                },
                new DbParameterInfo
                {
                    Name = "@ReturnDate",
                    DbType = DbType.DateTime,
                    Value = model.ReturnDate,
                },
                new DbParameterInfo
                {
                    Name = "@TotalReturnAmount",
                    DbType = DbType.Decimal,
                    Value = model.TotalReturnAmount,
                },
                new DbParameterInfo
                {
                    Name = "@TransactionID",
                    DbType = DbType.Int64,
                    Value = model.TransactionID,
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
                model.ReturnID = result.Data;

                return Result.Success();
            }

            return Result.Failure("فشلت عملية إضافة فاتورة المرتجع هذه!");
        }
    }
}

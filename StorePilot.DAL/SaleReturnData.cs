using DevToolkit.Core.Results;
using DevToolkit.Data;
using DevToolkit.Data.Core;
using StorePilot.Core.Enums;
using StorePilot.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StorePilot.DAL
{
    public static class SaleReturnData
    {
        //used
        public static Result<SaleReturnModel> Find(int id)
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

        //used
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

        //used
        public static Result CancellSalesReturns(
            IDbConnection con,
            IDbTransaction trans,
            int saleInvoiceId)
        {
            string Query = @"UPDATE SalesReturns
                SET
                    Cancelled = CASE Cancelled
                    WHEN 0 THEN 1
                    ELSE 1
                END
                WHERE SaleInvoiceID = @SaleInvoiceID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@SaleInvoiceID",
                    DbType = DbType.Int64,
                    Value = saleInvoiceId,
                },
            };

            Result<int> result = DbManager.Current?.ExecuteNonQuery(
                con,
                trans,
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
                return Result.Success();

            return Result.Failure("فشلت عملية إلغاء مرتجعات الفاتورة!");
        }

        //used
        public static Result Cancell(
            IDbConnection con,
            IDbTransaction trans,
            int returnId)
        {
            string Query = @"UPDATE SalesReturns
                SET
                    Cancelled = CASE Cancelled
                    WHEN 0 THEN 1
                    ELSE 1
                END
                WHERE ReturnID = @ReturnID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@ReturnID",
                    DbType = DbType.Int64,
                    Value = returnId,
                },
            };

            Result<int> result = DbManager.Current?.ExecuteNonQuery(
                con,
                trans,
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
                return Result.Success();

            return Result.Failure("فشلت عملية إلغاء فاتورة المرتجع!");
        }

        //used
        public static Result<bool> IsReturnsTransaction(int transId)
        {
            string Query = @"SELECT EXISTS
            (
                SELECT 1 FROM SalesReturns WHERE SaleInvoiceID = 
                (
                    SELECT SaleInvoiceID FROM SalesInvoices WHERE InvoiceID = 
                        (
                            SELECT InvoiceID FROM Invoices 
                            WHERE TransactionID = @TransactionID
                        )
                )
            ) AS IsReturnsTransaction;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@TransactionID",
                    DbType = DbType.Int64,
                    Value = transId,
                },
            };

            return DataQueryService.Scalar<bool>(CommandType.Text, Query, Parameters);
        }

        //used
        public static Result<bool> IsExist(int id)
        {
            string Query = @"SELECT EXISTS
                (
                    SELECT 1 FROM SalesReturns WHERE returnID = @returnID
                ) AS IsExist;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@returnID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.Scalar<bool>(
                CommandType.Text,
                Query,
                Parameters);
        }

        //used
        public static Result<int> GetCount(
            int saleInvoiceId,
            int filterMethodIndex,
            string filterValue,
            bool cancelled)
        {
            string Query = string.Empty;

            DbParameterInfo parameter = new DbParameterInfo
            {
                Name = "@FilterValue",
                DbType = DbType.String,
                Value = filterValue,
            };

            switch (filterMethodIndex)
            {
                case (int)FilterMethodsSalesReturns.ReturnID:
                    Query = @"SELECT COUNT(ReturnID) FROM SalesReturns
                        WHERE ReturnID = @ReturnID 
                        AND SaleInvoiceID = @SaleInvoiceID
                        AND Cancelled = @Cancelled;";

                    parameter = new DbParameterInfo
                    {
                        Name = "@FilterValue",
                        DbType = DbType.Int64,
                        Value = int.TryParse(filterValue?.ToString(),
                            out int ReturnID) ?
                            ReturnID : 0,
                    };

                    break;

                case (int)FilterMethodsSalesReturns.ReturnDate:
                    Query = @"SELECT COUNT(ReturnID) FROM SalesReturns
                        WHERE ReturnDate LIKE @FilterValue || '%'
                        AND SaleInvoiceID = @SaleInvoiceID
                        AND Cancelled = @Cancelled;";
                    break;

                default:
                    Query = @"SELECT COUNT(ReturnID) FROM SalesReturns
                        WHERE SaleInvoiceID = @SaleInvoiceID
                        AND Cancelled = @Cancelled;";
                    break;
            }

            List<DbParameterInfo> Parameters = new List<DbParameterInfo>
            {
                new DbParameterInfo
                {
                    Name = "@SaleInvoiceID",
                    DbType = DbType.Int64,
                    Value = saleInvoiceId,
                },
                new DbParameterInfo
                {
                    Name = "@Cancelled",
                    DbType = DbType.Boolean,
                    Value = cancelled,
                },
            };

            Parameters.Add(parameter);

            return DataQueryService.Scalar<int>(
                CommandType.Text,
                Query,
                Parameters);
        }

        //used
        public static Result<DataTable> GetInvoices(
            int saleInvoiceId,
            int offset,
            int pageSize,
            int filterMethodIndex,
            string filterValue,
            bool cancelled)
        {
            string Query = string.Empty;

            DbParameterInfo parameter = new DbParameterInfo
            {
                Name = "@FilterValue",
                DbType = DbType.String,
                Value = filterValue,
            };

            switch (filterMethodIndex)
            {
                case (int)FilterMethodsSalesReturns.ReturnID:
                    Query = @"SELECT ReturnID, SaleInvoiceID, 
                        ReturnDate, TotalReturnAmount, Cancelled
                        FROM SalesReturns
                        WHERE ReturnID = @FilterValue 
                        AND SaleInvoiceID = @SaleInvoiceID
                        AND Cancelled = @Cancelled
                        LIMIT @PageSize
                        OFFSET @Offset;";

                    parameter = new DbParameterInfo
                    {
                        Name = "@FilterValue",
                        DbType = DbType.Int64,
                        Value = int.TryParse(filterValue?.ToString(),
                            out int ReturnID) ?
                            ReturnID : 0,
                    };

                    break;

                case (int)FilterMethodsSalesReturns.ReturnDate:
                    Query = @"SELECT ReturnID, SaleInvoiceID, 
                        ReturnDate, TotalReturnAmount, Cancelled
                        FROM SalesReturns
                        WHERE ReturnDate LIKE @FilterValue || '%'
                        AND SaleInvoiceID = @SaleInvoiceID
                        AND Cancelled = @Cancelled
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                default:
                    Query = @"SELECT ReturnID, SaleInvoiceID, 
                        ReturnDate, TotalReturnAmount, Cancelled
                        FROM SalesReturns
                        WHERE SaleInvoiceID = @SaleInvoiceID
                        AND Cancelled = @Cancelled
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;
            }

            List<DbParameterInfo> Parameters = new List<DbParameterInfo>
            {
                new DbParameterInfo
                {
                    Name = "@SaleInvoiceID",
                    DbType = DbType.Int64,
                    Value = saleInvoiceId,
                },
                new DbParameterInfo
                {
                    Name = "@PageSize",
                    DbType = DbType.Int64,
                    Value = pageSize,
                },
                new DbParameterInfo
                {
                    Name = "@Offset",
                    DbType = DbType.Int64,
                    Value = offset,
                },
                new DbParameterInfo
                {
                    Name = "@Cancelled",
                    DbType = DbType.Boolean,
                    Value = cancelled,
                },
            };

            Parameters.Add(parameter);

            return DbManager.Current?.GetDataTable(
                CommandType.Text,
                Query,
                Parameters);
        }
    }
}

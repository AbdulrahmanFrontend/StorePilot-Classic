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

namespace StorePilot.DAL
{
    public static class SaleInvoiceData
    {
        public static Result<SaleInvoiceModel> Find(int saleInvoiceId)
        {
            string Query = @"SELECT * FROM view_SalesInvoicesDetails 
                WHERE SaleInvoiceID = @SaleInvoiceID;";

            DbParameterInfo[] Paramters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@SaleInvoiceID",
                    DbType = DbType.Int64,
                    Value = saleInvoiceId,
                },
            };

            return DataQueryService.FirstOrDefault<SaleInvoiceModel>(
                CommandType.Text,
                Query,
                Paramters);
        }

        //public static Result<SaleInvoiceModel> FindByInvoiceID(int invoiceId)
        //{
        //    string Query = @"SELECT * FROM view_SalesInvoicesDetails 
        //        WHERE InvoiceID = @InvoiceID;";

        //    DbParameterInfo[] Paramters = new DbParameterInfo[]
        //    {
        //        new DbParameterInfo
        //        {
        //            Name = "@InvoiceID",
        //            DbType = DbType.Int64,
        //            Value = invoiceId,
        //        },
        //    };

        //    return DataQueryService.FirstOrDefault<SaleInvoiceModel>(
        //        CommandType.Text,
        //        Query,
        //        Paramters);
        //}

        public static Result AddNew(
            IDbConnection con,
            IDbTransaction trans,
            SaleInvoiceModel model)
        {
            string Query = @"INSERT INTO SalesInvoices
                (
                    InvoiceID,
                    CustomerID,
                    Notes
                )
                VALUES
                (
                    @InvoiceID,
                    @CustomerID,
                    @Notes
                );

                SELECT LAST_INSERT_ROWID();";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@InvoiceID",
                    DbType = DbType.Int64,
                    Value = model.InvoiceID,
                },
                new DbParameterInfo
                {
                    Name = "@CustomerID",
                    DbType = DbType.Int64,
                    Value = model.CustomerID,
                },
                new DbParameterInfo
                {
                    Name = "@Notes",
                    DbType = DbType.String,
                    Value = model.Notes,
                }
            };

            Result<int> result = DbManager.Current?.GetScalar<int>(
                con,
                trans,
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
            {
                model.SaleInvoiceID = result.Data;

                return Result.Success();
            }

            return Result.Failure("فشلت عملية إضافة فاتورة البيع!");
        }

        public static Result Update(
            IDbConnection con,
            IDbTransaction trans,
            SaleInvoiceModel model)
        {
            string Query = @"UPDATE SalesInvoices
                SET
                    CustomerID = @CustomerID
                WHERE SaleInvoiceID = @SaleInvoiceID;";

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
                    Name = "@CustomerID",
                    DbType = DbType.Int64,
                    Value = model.CustomerID,
                },
            };

            Result<int> result = DbManager.Current?.ExecuteNonQuery(
                con,
                trans,
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
            {
                if (result.Data == 0)
                    return Result.Failure("لم تحديث بيانات أي فاتورة بيع!");

                return Result.Success();
            }

            return Result.Failure("فشلت عملية تحديث بيانات فاتورة البيع!");
        }
        
        public static Result UpdateTotalAmountAfterCreatingReturns(
            IDbConnection con,
            IDbTransaction trans,
            int returnId)
        {
            string Query = @"UPDATE Invoices
                SET
                    PaidAmount = PaidAmount -
                    (
                        SELECT TotalReturnAmount FROM SalesReturns 
                        WHERE ReturnID = @ReturnID AND Cancelled = 0
                    )
                WHERE InvoiceID = 
                (
                    SELECT InvoiceID FROM SalesInvoices WHERE SaleInvoiceID =
                    (
                        SELECT SaleInvoiceID FROM SalesReturns WHERE ReturnID = @ReturnID
                    )
                );";

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

            return Result.Failure("فشلت عملية تحديث مبلغ السداد من الفاتورة");
        }

        public static Result UpdatePaidAmount(
            IDbConnection con,
            IDbTransaction trans,
            int returnId)
        {
            string Query = @"UPDATE Invoices
                SET
                    PaidAmount = TotalAmount
                WHERE InvoiceID = 
                (
                    SELECT InvoiceID FROM SalesInvoices WHERE SaleInvoiceID =
                    (
                        SELECT SaleInvoiceID FROM SalesReturns WHERE ReturnID = @ReturnID
                    )
                );";

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

            return Result.Failure("فشلت عملية تحديث مبلغ السداد من الفاتورة");
        }

        public static Result UpdateTotalAmount(
            IDbConnection con,
            IDbTransaction trans,
            int returnId)
        {
            string Query = @"UPDATE Invoices
                SET
                    TotalAmount = TotalAmount + 
                    (
                        SELECT TotalReturnAmount FROM SalesReturns
                        WHERE ReturnID = @ReturnID
                    )
                WHERE InvoiceID = 
                (
                    SELECT InvoiceID FROM SalesInvoices WHERE SaleInvoiceID = 
                    (
                        SELECT SaleInvoiceID FROM SalesReturns
                        WHERE ReturnID = @ReturnID
                    )
                );";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@ReturnID",
                    DbType = DbType.Int64,
                    Value = returnId,
                },
            };

            Result<int> result=DbManager.Current?.ExecuteNonQuery(
                con,
                trans,
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
            {
                if (result.Data > 0)
                    return Result.Success();

                return Result.Failure("لم يتم تحديث إجمالي أي فاتورة!");
            }

            return Result.Failure("فشلت عملية تحديث إجمالي الفاتورة!");
        }

        public static Result Cancell(
            IDbConnection con,
            IDbTransaction trans,
            int invoiceId)
        {
            string Query = @"UPDATE SalesInvoices
                SET
                    Cancelled = CASE Cancelled
                    WHEN 0 THEN 1
                    ELSE 1
                END
                WHERE InvoiceID = @InvoiceID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@InvoiceID",
                    DbType = DbType.Int64,
                    Value = invoiceId,
                },
            };

            Result<int> result = DbManager.Current?.ExecuteNonQuery(
                con,
                trans,
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
                return Result.Success("تمت عملية إلغاء هذه الفاتورة بنجاح.");

            return Result.Failure("فشلت عملية إلغاء هذه الفاتورة!");
        }

        public static Result<bool> IsFound(int id)
        {
            string Query = @"SELECT EXISTS
                (
                    SELECT 1 FROM SalesInvoices 
                    WHERE SaleInvoiceID = @SaleInvoiceID
                ) AS IsFound;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@SaleInvoiceID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.Scalar<bool>(
                CommandType.Text,
                Query,
                Parameters);
        }

        public static Result<int> GetCount()
        {
            string Query = @"SELECT COUNT(SaleInvoiceID) AS SalesInvoicesCount 
                    FROM SalesInvoices WHERE Cancelled = 0;";

            return DataQueryService.Scalar<int>(CommandType.Text, Query);
        }

        public static Result<int> GetCount(
            int filterMethodIndex,
            string filterValue)
        {
            string Query = string.Empty;

            switch (filterMethodIndex)
            {
                case (int)FilterMethodsInvoices.Name:
                    Query = @"SELECT COUNT(SaleInvoiceID)
                        FROM view_SalesInvoicesDetails
                        WHERE CustomerName LIKE @FilterValue || '%';";
                    break;

                case (int)FilterMethodsInvoices.InvoiceDate:
                    Query = @"SELECT COUNT(SaleInvoiceID)
                        FROM view_SalesInvoicesDetails
                        WHERE InvoiceDate LIKE @FilterValue || '%';";
                    break;

                case (int)FilterMethodsInvoices.InvoiceStatus:
                    Query = @"SELECT COUNT(SaleInvoiceID)
                        FROM view_SalesInvoicesDetails
                        WHERE InvoiceStatus LIKE @FilterValue || '%';";
                    break;

                default:
                    Query = @"SELECT COUNT(SaleInvoiceID)
                        FROM view_SalesInvoicesDetails;";
                    break;
            }

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@FilterValue",
                    DbType = DbType.String,
                    Value = filterValue,
                },
            };

            return DataQueryService.Scalar<int>(
                CommandType.Text,
                Query,
                Parameters);
        }

        public static Result<DataTable> GetInvoices(
            int offset,
            int pageSize,
            int filterMethodIndex,
            string filterValue)
        {
            string Query = string.Empty;

            switch (filterMethodIndex)
            {
                case (int)FilterMethodsInvoices.Name:
                    Query = @"SELECT SaleInvoiceID, InvoiceDate, InvoiceStatus,
                        PaidAmount, (TotalAmount - PaidAmount) AS RemainingAmount,
                        CustomerName, TotalAmount, CreatedAt
                        FROM view_SalesInvoicesDetails
                        WHERE CustomerName LIKE @FilterValue || '%'
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsInvoices.InvoiceDate:
                    Query = @"SELECT SaleInvoiceID, InvoiceDate, InvoiceStatus,
                        PaidAmount, (TotalAmount - PaidAmount) AS RemainingAmount,
                        CustomerName, TotalAmount, CreatedAt
                        FROM view_SalesInvoicesDetails
                        WHERE InvoiceDate LIKE @FilterValue || '%'
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsInvoices.InvoiceStatus:
                    Query = @"SELECT SaleInvoiceID, InvoiceDate, InvoiceStatus,
                        PaidAmount, (TotalAmount - PaidAmount) AS RemainingAmount,
                        CustomerName, TotalAmount, CreatedAt
                        FROM view_SalesInvoicesDetails
                        WHERE InvoiceStatus LIKE @FilterValue || '%'
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                default:
                    Query = @"SELECT SaleInvoiceID, InvoiceDate, InvoiceStatus,
                        PaidAmount, (TotalAmount - PaidAmount) AS RemainingAmount,
                        CustomerName, TotalAmount, CreatedAt
                        FROM view_SalesInvoicesDetails
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;
            }

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@FilterValue",
                    DbType = DbType.String,
                    Value = filterValue,
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
                }
            };

            return DbManager.Current?.GetDataTable(
                CommandType.Text,
                Query,
                Parameters);
        }

        public static Result<bool> IsRevenu(int transId)
        {
            string Query = @"SELECT EXISTS
            (
                SELECT 1 FROM SalesInvoices WHERE InvoiceID = 
                (
                    SELECT InvoiceID FROM Invoices WHERE TransactionID = @TransactionID
                )
            ) AS IsRevenu;";

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

        //public static Result<bool> IsCancelled(int id)
        //{
        //    string Query = @"SELECT Cancelled FROM SalesInvoices
        //        WHERE SaleInvoiceID = @SaleInvoiceID;";

        //    DbParameterInfo[] Parameters = new DbParameterInfo[]
        //    {
        //        new DbParameterInfo
        //        {
        //            Name = "@SaleInvoiceID",
        //            DbType = DbType.Int64,
        //            Value = id,
        //        },
        //    };

        //    return DataQueryService.Scalar<bool>(CommandType.Text, Query, Parameters);
        //}

        public static Result<decimal> GetDebtsSum()
        {
            string Query = @"SELECT COALESCE(
                SUM(
                    CASE
                        WHEN InvoiceStatus = @InvoiceStatus
                        THEN (TotalAmount - PaidAmount)
                    END
                ), 0) AS DebtsSum FROM view_SalesInvoicesDetails
                WHERE Cancelled = 0;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@InvoiceStatus",
                    DbType = DbType.String,
                    Value = InvoiceStatus.Deferred.ToArabic(),
                }
            };

            return DataQueryService.Scalar<decimal>(CommandType.Text, Query, Parameters);
        }
    }
}

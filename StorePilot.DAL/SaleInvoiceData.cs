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
        //used
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

        //used
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

        //used
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

        //used
        public static Result<bool> IsExist(int id)
        {
            string Query = @"SELECT EXISTS
                (
                    SELECT 1 FROM view_SalesInvoicesDetails 
                    WHERE SaleInvoiceID = @SaleInvoiceID
                ) AS IsExist;";

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

        //used
        public static Result<int> GetCount(
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
                case (int)FilterMethodsSalesInvoices.SaleInvoiceID:
                    Query = @"SELECT COUNT(SaleInvoiceID)
                        FROM view_SalesInvoicesDetails
                        WHERE SaleInvoiceID = @FilterValue
                        AND Cancelled = @Cancelled;";
                    
                    parameter = new DbParameterInfo
                    {
                        Name = "@FilterValue",
                        DbType = DbType.Int64,
                        Value = int.TryParse(filterValue?.ToString(),
                                out int SaleInvoiceID) ?
                                SaleInvoiceID : 0,
                    };

                    break;

                case (int)FilterMethodsSalesInvoices.InvoiceID:
                    Query = @"SELECT COUNT(SaleInvoiceID)
                        FROM view_SalesInvoicesDetails
                        WHERE InvoiceID = @FilterValue
                        AND Cancelled = @Cancelled;";

                    parameter = new DbParameterInfo
                    {
                        Name = "@FilterValue",
                        DbType = DbType.Int64,
                        Value = int.TryParse(filterValue?.ToString(),
                                out int InvoiceID) ?
                                InvoiceID : 0
                    };

                    break;

                case (int)FilterMethodsSalesInvoices.CustomerName:
                    Query = @"SELECT COUNT(SaleInvoiceID)
                        FROM view_SalesInvoicesDetails
                        WHERE CustomerName LIKE @FilterValue || '%'
                        AND Cancelled = @Cancelled;";
                    break;

                case (int)FilterMethodsSalesInvoices.InvoiceDate:
                    Query = @"SELECT COUNT(SaleInvoiceID)
                        FROM view_SalesInvoicesDetails
                        WHERE InvoiceDate LIKE @FilterValue || '%'
                        AND Cancelled = @Cancelled;";
                    break;

                case (int)FilterMethodsSalesInvoices.InvoiceStatus:
                    Query = @"SELECT COUNT(SaleInvoiceID)
                        FROM view_SalesInvoicesDetails
                        WHERE InvoiceStatus LIKE @FilterValue || '%'
                        AND Cancelled = @Cancelled;";
                    break;

                default:
                    Query = @"SELECT COUNT(SaleInvoiceID)
                        FROM view_SalesInvoicesDetails
                        WHERE Cancelled = @Cancelled;";
                    break;
            }

            List<DbParameterInfo> Parameters = new List<DbParameterInfo>
            {
                new DbParameterInfo
                {
                    Name = "@FilterValue",
                    DbType = DbType.String,
                    Value = filterValue,
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
                case (int)FilterMethodsSalesInvoices.SaleInvoiceID:
                    Query = @"SELECT SaleInvoiceID, InvoiceID, InvoiceDate,
                        InvoiceStatus, PaidAmount, 
                        (TotalAmount - PaidAmount) AS RemainingAmount,
                        CustomerName, TotalAmount, CreatedAt, Cancelled
                        FROM view_SalesInvoicesDetails
                        WHERE SaleInvoiceID = @FilterValue
                        AND Cancelled = @Cancelled
                        LIMIT @PageSize
                        OFFSET @Offset;";

                    parameter = new DbParameterInfo
                    {
                        Name = "@FilterValue",
                        DbType = DbType.Int64,
                        Value = int.TryParse(filterValue?.ToString(),
                            out int SaleInvoiceID) ?
                            SaleInvoiceID : 0
                    };

                    break;

                case (int)FilterMethodsSalesInvoices.InvoiceID:
                    Query = @"SELECT SaleInvoiceID, InvoiceID, InvoiceDate,
                        InvoiceStatus, PaidAmount, 
                        (TotalAmount - PaidAmount) AS RemainingAmount,
                        CustomerName, TotalAmount, CreatedAt, Cancelled
                        FROM view_SalesInvoicesDetails
                        WHERE InvoiceID = @FilterValue
                        AND Cancelled = @Cancelled
                        LIMIT @PageSize
                        OFFSET @Offset;";

                    parameter = new DbParameterInfo
                    {
                        Name = "@FilterValue",
                        DbType = DbType.Int64,
                        Value = int.TryParse(filterValue?.ToString(),
                            out int InvoiceID) ?
                            InvoiceID : 0
                    };

                    break;

                case (int)FilterMethodsSalesInvoices.CustomerName:
                    Query = @"SELECT SaleInvoiceID, InvoiceID, InvoiceDate,
                        InvoiceStatus, PaidAmount, 
                        (TotalAmount - PaidAmount) AS RemainingAmount,
                        CustomerName, TotalAmount, CreatedAt, Cancelled
                        FROM view_SalesInvoicesDetails
                        WHERE CustomerName LIKE @FilterValue || '%'
                        AND Cancelled = @Cancelled
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsSalesInvoices.InvoiceDate:
                    Query = @"SELECT SaleInvoiceID, InvoiceID, InvoiceDate,
                        InvoiceStatus, PaidAmount, 
                        (TotalAmount - PaidAmount) AS RemainingAmount,
                        CustomerName, TotalAmount, CreatedAt, Cancelled
                        FROM view_SalesInvoicesDetails
                        WHERE InvoiceDate LIKE @FilterValue || '%'
                        AND Cancelled = @Cancelled
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsSalesInvoices.InvoiceStatus:
                    Query = @"SELECT SaleInvoiceID, InvoiceID, InvoiceDate,
                        InvoiceStatus, PaidAmount, 
                        (TotalAmount - PaidAmount) AS RemainingAmount,
                        CustomerName, TotalAmount, CreatedAt, Cancelled
                        FROM view_SalesInvoicesDetails
                        WHERE InvoiceStatus LIKE @FilterValue || '%'
                        AND Cancelled = @Cancelled
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                default:
                    Query = @"SELECT SaleInvoiceID, InvoiceID, InvoiceDate,
                        InvoiceStatus, PaidAmount, 
                        (TotalAmount - PaidAmount) AS RemainingAmount,
                        CustomerName, TotalAmount, CreatedAt, Cancelled
                        FROM view_SalesInvoicesDetails
                        WHERE Cancelled = @Cancelled
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;
            }

            List<DbParameterInfo> Parameters = new List<DbParameterInfo>
            {
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

        //used
        public static Result<bool> HasReturns(int id)
        {
            string Query = @"SELECT EXISTS
                (
                    SELECT 1 FROM SalesReturns WHERE SaleInvoiceID = @SaleInvoiceID
                ) AS IsExist;";

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

        //used
        public static Result<bool> IsSalesTransaction(int transId)
        {
            string Query = @"SELECT EXISTS
            (
                SELECT 1 FROM SalesInvoices WHERE InvoiceID = 
                (
                    SELECT InvoiceID FROM Invoices WHERE TransactionID = @TransactionID
                )
            ) AS IsPurchaseTransaction;";

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
    }
}

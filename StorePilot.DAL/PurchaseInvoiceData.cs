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
    public static class PurchaseInvoiceData
    {
        public static Result<PurchaseInvoiceModel> Find(
            int purchaseInvoiceId)
        {
            string Query = @"SELECT * FROM view_PurchasesInvoicesDetails 
                WHERE PurchaseInvoiceID = @PurchaseInvoiceID;";

            DbParameterInfo[] Paramters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@PurchaseInvoiceID",
                    DbType = DbType.Int64,
                    Value = purchaseInvoiceId,
                },
            };

            return DataQueryService.FirstOrDefault<PurchaseInvoiceModel>(
                CommandType.Text,
                Query,
                Paramters);
        }

        //public static Result<PurchaseInvoiceModel> FindByInvoiceID(int invoiceId)
        //{
        //    string Query = @"SELECT * FROM view_PurchasesInvoicesDetails 
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

        //    return DataQueryService.FirstOrDefault<PurchaseInvoiceModel>(
        //        CommandType.Text,
        //        Query,
        //        Paramters);
        //}

        public static Result AddNew(
            IDbConnection con,
            IDbTransaction trans,
            PurchaseInvoiceModel model)
        {
            string Query = @"INSERT INTO PurchaseInvoices
                (
                    InvoiceID,
                    SupplierID,
                    Notes
                )
                VALUES
                (
                    @InvoiceID,
                    @SupplierID,
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
                    Name = "@SupplierID",
                    DbType = DbType.Int64,
                    Value = model.SupplierID,
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
                model.PurchaseInvoiceID = result.Data;

                return Result.Success();
            }

            return Result.Failure("فشلت عملية إضافة فاتورة الشراء!");
        }

        public static Result Update(
            IDbConnection con,
            IDbTransaction trans,
            PurchaseInvoiceModel model)
        {
            string Query = @"UPDATE PurchasesInvoices
                SET
                    SupplierID = @SupplierID
                WHERE PurchaseInvoiceID = @PurchaseInvoiceID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@PurchaseInvoiceID",
                    DbType = DbType.Int64,
                    Value = model.PurchaseInvoiceID,
                },
                new DbParameterInfo
                {
                    Name = "@SupplierID",
                    DbType = DbType.Int64,
                    Value = model.SupplierID,
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
                    return Result.Failure("لم تحديث بيانات أي فاتورة شراء!");

                return Result.Success();
            }

            return Result.Failure("فشلت عملية تحديث بيانات فاتورة الشراء!");
        }

        public static Result Cancell(
            IDbConnection con,
            IDbTransaction trans,
            int invoiceId)
        {
            string Query = @"UPDATE PurchasesInvoices
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
                    SELECT 1 FROM PurchasesInvoices 
                    WHERE PurchaseInvoiceID = @PurchaseInvoiceID
                ) AS IsFound;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@PurchaseInvoiceID",
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
            string Query = @"SELECT COUNT(PurchaseInvoiceID) AS PurchasesInvoicesCount 
                    FROM PurchaseInvoices WHERE Cancelled = 0;";

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
                    Query = @"SELECT COUNT(PurchaseInvoiceID)
                        FROM view_PurchasesInvoicesDetails
                        WHERE SupplierName LIKE @FilterValue || '%';";
                    break;

                case (int)FilterMethodsInvoices.InvoiceDate:
                    Query = @"SELECT COUNT(PurchaseInvoiceID)
                        FROM view_PurchasesInvoicesDetails
                        WHERE InvoiceDate LIKE @FilterValue || '%';";
                    break;

                case (int)FilterMethodsInvoices.InvoiceStatus:
                    Query = @"SELECT COUNT(PurchaseInvoiceID)
                        FROM view_PurchasesInvoicesDetails
                        WHERE InvoiceStatus LIKE @FilterValue || '%';";
                    break;

                default:
                    Query = @"SELECT COUNT(PurchaseInvoiceID)
                        FROM view_PurchasesInvoicesDetails;";
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
                    Query = @"SELECT PurchaseInvoiceID, InvoiceDate, InvoiceStatus,
                        PaidAmount, (TotalAmount - PaidAmount) AS RemainingAmount,
                        SupplierName, TotalAmount, CreatedAt
                        FROM view_PurchasesInvoicesDetails
                        WHERE SupplierName LIKE @FilterValue || '%'
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsInvoices.InvoiceDate:
                    Query = @"SELECT PurchaseInvoiceID, InvoiceDate, InvoiceStatus,
                        PaidAmount, (TotalAmount - PaidAmount) AS RemainingAmount,
                        SupplierName, TotalAmount, CreatedAt
                        FROM view_PurchasesInvoicesDetails
                        WHERE InvoiceDate LIKE @FilterValue || '%'
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsInvoices.InvoiceStatus:
                    Query = @"SELECT PurchaseInvoiceID, InvoiceDate, InvoiceStatus,
                        PaidAmount, (TotalAmount - PaidAmount) AS RemainingAmount,
                        SupplierName, TotalAmount, CreatedAt
                        FROM view_PurchasesInvoicesDetails
                        WHERE InvoiceStatus LIKE @FilterValue || '%'
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                default:
                    Query = @"SELECT PurchaseInvoiceID, InvoiceDate, InvoiceStatus,
                        PaidAmount, (TotalAmount - PaidAmount) AS RemainingAmount,
                        SupplierName, TotalAmount, CreatedAt
                        FROM view_PurchasesInvoicesDetails
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

        public static Result<bool> IsPurchaseTransaction(int transId)
        {
            string Query = @"SELECT EXISTS
            (
                SELECT 1 FROM PurchasesInvoices WHERE InvoiceID = 
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

        //public static Result<bool> IsCancelled(int id)
        //{
        //    string Query = @"SELECT Cancelled FROM PurchasesInvoices
        //        WHERE PurchaseInvoiceID = @PurchaseInvoiceID;";

        //    DbParameterInfo[] Parameters = new DbParameterInfo[]
        //    {
        //        new DbParameterInfo
        //        {
        //            Name = "@PurchaseInvoiceID",
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
                        THEN (TotalAmount - PaidAmount) AS RemainingAmount
                    END
                ), 0) AS DebtsSum FROM view_PurchasesInvoicesDetails
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

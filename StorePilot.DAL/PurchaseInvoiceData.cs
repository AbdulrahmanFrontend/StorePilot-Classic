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
        //used
        public static Result<PurchaseInvoiceModel> Find(int id)
        {
            string Query = @"SELECT * FROM view_PurchasesInvoicesDetails 
                WHERE PurchaseInvoiceID = @PurchaseInvoiceID;";

            DbParameterInfo[] Paramters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@PurchaseInvoiceID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.FirstOrDefault<PurchaseInvoiceModel>(
                CommandType.Text,
                Query,
                Paramters);
        }

        //used
        public static Result AddNew(
            IDbConnection con,
            IDbTransaction trans,
            PurchaseInvoiceModel model)
        {
            string Query = @"INSERT INTO PurchasesInvoices
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

        //used
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

        //used
        public static Result<bool> IsExist(int id)
        {
            string Query = @"SELECT EXISTS
                (
                    SELECT 1 FROM view_PurchasesInvoicesDetails 
                    WHERE PurchaseInvoiceID = @PurchaseInvoiceID
                ) AS IsExist;";

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

        //used
        public static Result<int> GetCount(
            int filterMethodIndex,
            string filterValue,
            bool cancalled)
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
                case (int)FilterMethodsPurchasesInvoices.PurchaseInvoiceID:
                    Query = @"SELECT COUNT(PurchaseInvoiceID)
                        FROM view_PurchasesInvoicesDetails
                        WHERE PurchaseInvoiceID = @FilterValue
                        AND Cancelled = @Cancelled;";

                    parameter = new DbParameterInfo
                    {
                        Name = "@FilterValue",
                        DbType = DbType.Int64,
                        Value = int.TryParse(filterValue?.ToString(),
                                out int PurchaseInvoiceID) ?
                                PurchaseInvoiceID : 0,
                    };

                    break;

                case (int)FilterMethodsPurchasesInvoices.InvoiceID:
                    Query = @"SELECT COUNT(PurchaseInvoiceID)
                        FROM view_PurchasesInvoicesDetails
                        WHERE InvoiceID = @FilterValue
                        AND Cancelled = @Cancelled;";

                    parameter = new DbParameterInfo
                    {
                        Name = "@FilterValue",
                        DbType = DbType.Int64,
                        Value = int.TryParse(filterValue?.ToString(),
                                out int InvoiceID) ?
                                InvoiceID : 0,
                    };

                    break;

                case (int)FilterMethodsPurchasesInvoices.SupplierName:
                    Query = @"SELECT COUNT(PurchaseInvoiceID)
                        FROM view_PurchasesInvoicesDetails
                        WHERE SupplierName LIKE @FilterValue || '%'
                        AND Cancelled = @Cancelled;";
                    break;

                case (int)FilterMethodsPurchasesInvoices.InvoiceDate:
                    Query = @"SELECT COUNT(PurchaseInvoiceID)
                        FROM view_PurchasesInvoicesDetails
                        WHERE InvoiceDate LIKE @FilterValue || '%'
                        AND Cancelled = @Cancelled;";
                    break;

                case (int)FilterMethodsPurchasesInvoices.InvoiceStatus:
                    Query = @"SELECT COUNT(PurchaseInvoiceID)
                        FROM view_PurchasesInvoicesDetails
                        WHERE InvoiceStatus LIKE @FilterValue || '%'
                        AND Cancelled = @Cancelled;";
                    break;

                default:
                    Query = @"SELECT COUNT(PurchaseInvoiceID)
                        FROM view_PurchasesInvoicesDetails
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
                    Value = cancalled,
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
                case (int)FilterMethodsPurchasesInvoices.PurchaseInvoiceID:
                    Query = @"SELECT PurchaseInvoiceID, InvoiceID, 
                        InvoiceDate, InvoiceStatus, PaidAmount,
                        (TotalAmount - PaidAmount) AS RemainingAmount,
                        SupplierName, TotalAmount, CreatedAt, Cancelled
                        FROM view_PurchasesInvoicesDetails
                        WHERE PurchaseInvoiceID = @FilterValue
                        AND Cancelled = @Cancelled
                        LIMIT @PageSize
                        OFFSET @Offset;";

                    parameter = new DbParameterInfo
                    {
                        Name = "@FilterValue",
                        DbType = DbType.Int64,
                        Value = int.TryParse(filterValue?.ToString(),
                            out int PurchaseInvoiceID) ?
                            PurchaseInvoiceID : 0,
                    };

                    break;

                case (int)FilterMethodsPurchasesInvoices.InvoiceID:
                    Query = @"SELECT PurchaseInvoiceID, InvoiceID, 
                        InvoiceDate, InvoiceStatus, PaidAmount,
                        (TotalAmount - PaidAmount) AS RemainingAmount,
                        SupplierName, TotalAmount, CreatedAt, Cancelled
                        FROM view_PurchasesInvoicesDetails
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
                            InvoiceID : 0,
                    };

                    break;

                case (int)FilterMethodsPurchasesInvoices.SupplierName:
                    Query = @"SELECT PurchaseInvoiceID, InvoiceID, 
                        InvoiceDate, InvoiceStatus, PaidAmount,
                        (TotalAmount - PaidAmount) AS RemainingAmount,
                        SupplierName, TotalAmount, CreatedAt, Cancelled
                        FROM view_PurchasesInvoicesDetails
                        WHERE SupplierName LIKE @FilterValue || '%'
                        AND Cancelled = @Cancelled
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsPurchasesInvoices.InvoiceDate:
                    Query = @"SELECT PurchaseInvoiceID, InvoiceID, 
                        InvoiceDate, InvoiceStatus, PaidAmount,
                        (TotalAmount - PaidAmount) AS RemainingAmount,
                        SupplierName, TotalAmount, CreatedAt, Cancelled
                        FROM view_PurchasesInvoicesDetails
                        WHERE InvoiceDate LIKE @FilterValue || '%'
                        AND Cancelled = @Cancelled
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsPurchasesInvoices.InvoiceStatus:
                    Query = @"SELECT PurchaseInvoiceID, InvoiceID, 
                        InvoiceDate, InvoiceStatus, PaidAmount,
                        (TotalAmount - PaidAmount) AS RemainingAmount,
                        SupplierName, TotalAmount, CreatedAt, Cancelled
                        FROM view_PurchasesInvoicesDetails
                        WHERE InvoiceStatus LIKE @FilterValue || '%'
                        AND Cancelled = @Cancelled
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                default:
                    Query = @"SELECT PurchaseInvoiceID, InvoiceID, 
                        InvoiceDate, InvoiceStatus, PaidAmount,
                        (TotalAmount - PaidAmount) AS RemainingAmount,
                        SupplierName, TotalAmount, CreatedAt, Cancelled
                        FROM view_PurchasesInvoicesDetails
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
                }
            };

            Parameters.Add(parameter);

            return DbManager.Current?.GetDataTable(
                CommandType.Text,
                Query,
                Parameters);
        }

        //used
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

        //used
        public static Result<bool> Cancelled(int inoiceId)
        {
            string Query = @"SELECT EXISTS
            (
                SELECT 1 FROM PurchasesInvoices 
                WHERE InvoiceID = @InvoiceID AND Cancelled = 1
            ) AS Cancelled;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@InvoiceID",
                    DbType = DbType.Int64,
                    Value = inoiceId,
                },
            };

            return DataQueryService.Scalar<bool>(CommandType.Text, Query, Parameters);
        }
    }
}

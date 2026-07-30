using DevToolkit.Core.Results;
using DevToolkit.Data;
using DevToolkit.Data.Core;
using DevToolkit.Logging.Managers;
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
    public static class CashTransactionData
    {
        //used
        public static Result<CashTransactionModel> Find(int id)
        {
            string Query = @"SELECT * FROM CashTransactions 
                WHERE TransactionID = @TransactionID;";

            DbParameterInfo[] Paramters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@TransactionID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.FirstOrDefault<CashTransactionModel>(
                CommandType.Text,
                Query,
                Paramters);
        }

        //used
        public static Result AddNew(CashTransactionModel model)
        {
            string Query = @"INSERT INTO CashTransactions 
                (
                    TransactionDate,
                    TransactionType,
                    PaidAmount,
                    Description,
                    Notes
                )
                VALUES
                (
                    @TransactionDate,
                    @TransactionType,
                    @PaidAmount,
                    @Description,
                    @Notes
                );

                SELECT LAST_INSERT_ROWID();";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@TransactionDate",
                    DbType = DbType.Date,
                    Value = model.TransactionDate,
                },
                new DbParameterInfo
                {
                    Name = "@PaidAmount",
                    DbType = DbType.Decimal,
                    Value = model.PaidAmount,
                },
                new DbParameterInfo
                {
                    Name = "@Description",
                    DbType = DbType.String,
                    Value = model.Description,
                },
                new DbParameterInfo
                {
                    Name = "@TransactionType",
                    DbType = DbType.String,
                    Value = TransactionType.Expense.ToArabic(),
                },
                new DbParameterInfo
                {
                    Name = "@Notes",
                    DbType = DbType.String,
                    Value = model.Notes,
                },
            };

            Result<int> result = DbManager.Current?.GetScalar<int>(
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
            {
                model.TransactionID = result.Data;

                LogManager.LogInfo($"تمت عملية إضافة حركة {model.TransactionID} بنجاح.");

                return Result.Success("تمت عملية حفظ بيانات هذه المصروفات بنجاح.");
            }

            return Result.Failure("فشلت عملية حفظ بيانات حركة الصندوق هذه!");
        }

        //used
        public static Result AddNew(
            IDbConnection con,
            IDbTransaction trans,
            CashTransactionModel model)
        {
            string Query = @"INSERT INTO CashTransactions 
                (
                    TransactionDate,
                    TransactionType,
                    PaidAmount,
                    Description,
                    Notes
                )
                VALUES
                (
                    @TransactionDate,
                    @TransactionType,
                    @PaidAmount,
                    @Description,
                    @Notes
                );

                SELECT LAST_INSERT_ROWID();";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@TransactionDate",
                    DbType = DbType.Date,
                    Value = model.TransactionDate,
                },
                new DbParameterInfo
                {
                    Name = "@PaidAmount",
                    DbType = DbType.Decimal,
                    Value = model.PaidAmount,
                },
                new DbParameterInfo
                {
                    Name = "@Description",
                    DbType = DbType.String,
                    Value = model.Description,
                },
                new DbParameterInfo
                {
                    Name = "@TransactionType",
                    DbType = DbType.String,
                    Value = TransactionType.Expense.ToArabic(),
                },
                new DbParameterInfo
                {
                    Name = "@Notes",
                    DbType = DbType.String,
                    Value = model.Notes,
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
                model.TransactionID = result.Data;

                return Result.Success();
            }

            return Result.Failure(
                "فشلت عملية إضافة حركة صندوق لهذه الفاتورة!");
        }

        public static Result Update(
            IDbConnection con,
            IDbTransaction trans,
            CashTransactionModel model)
        {
            string Query = @"UPDATE CashTransactions
                SET
                    TransactionDate = @TransactionDate
                WHERE TransactionID = @TransactionID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@TransactionID",
                    DbType = DbType.Int64,
                    Value = model.TransactionID,
                },
                new DbParameterInfo
                {
                    Name = "@TransactionDate",
                    DbType = DbType.DateTime,
                    Value = model.TransactionDate,
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
                if (result.Data > 0)
                    return Result.Success();

                return Result.Failure("لم يتم تحديث بيانات أي حركة!");
            }

            return Result.Failure(
                "فشلت عملية إضافة حركة صندوق لهذه الفاتورة!");
        }

        //public static Result AddNewSalesTransaction(
        //    IDbConnection con,
        //    IDbTransaction trans,
        //    CashTransactionModel model)
        //{
        //    string Query = @"INSERT INTO CashTransactions 
        //        (
        //            TransactionDate,
        //            TransactionType,
        //            Amount,
        //            Description
        //        )
        //        VALUES
        //        (
        //            @TransactionDate,
        //            @TransactionType,
        //            @Amount,
        //            @Description
        //        );

        //        SELECT last_insert_rowid();";

        //    DbParameterInfo[] Parameters = new DbParameterInfo[]
        //    {
        //        new DbParameterInfo
        //        {
        //            Name = "@TransactionDate",
        //            DbType = DbType.DateTime,
        //            Value = model.TransactionDate,
        //        },
        //        new DbParameterInfo
        //        {
        //            Name = "@Amount",
        //            DbType = DbType.Double,
        //            Value = model.Amount,
        //        },
        //        new DbParameterInfo
        //        {
        //            Name = "@Description",
        //            DbType = DbType.String,
        //            Value = model.Description,
        //        },
        //        new DbParameterInfo
        //        {
        //            Name = "@TransactionType",
        //            DbType = DbType.String,
        //            Value = TransactionType.Revenue.ToArabic(),
        //        }
        //    };

        //    var result = DbManager.Current?.GetScalar<int>(
        //        con,
        //        trans,
        //        CommandType.Text,
        //        Query,
        //        Parameters);

        //    if (result.IsSuccess)
        //    {
        //        model.TransactionID = result.Data;

        //        return Result.Success();
        //    }

        //    return Result.Failure(
        //        "فشلت عملية إضافة حركة صندوق لعملية الدفع هذه!");
        //}

        //used
        public static Result Update(CashTransactionModel model)
        {
            string Query = @"UPDATE CashTransactions
                SET
                    TransactionDate = @TransactionDate, PaidAmount = @PaidAmount,
                    TransactionType = @TransactionType, Notes = @Notes,
                    Description = @Description
                WHERE TransactionID = @TransactionID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@TransactionID",
                    DbType = DbType.Int64,
                    Value = model.TransactionID,
                },
                new DbParameterInfo
                {
                    Name = "@TransactionDate",
                    DbType = DbType.DateTime,
                    Value = model.TransactionDate,
                },
                new DbParameterInfo
                {
                    Name = "@PaidAmount",
                    DbType = DbType.Decimal,
                    Value = model.PaidAmount,
                },
                new DbParameterInfo
                {
                    Name = "@Description",
                    DbType = DbType.String,
                    Value = model.Description,
                },
                new DbParameterInfo
                {
                    Name = "@TransactionType",
                    DbType = DbType.String,
                    Value = TransactionType.Expense.ToArabic(),
                },
                new DbParameterInfo
                {
                    Name = "@Notes",
                    DbType = DbType.String,
                    Value = model.Notes,
                },
            };

            Result<int> result = DbManager.Current?.ExecuteNonQuery(
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
            {
                if (result.Data == 0)
                    return Result.Failure("لم تحديث بيانات أي حركة!");

                LogManager.LogInfo(
                    $"تمت عملية تحديث بيانات هذه الحركة {model.TransactionID} بنجاح.");

                return Result.Success("تمت عملية حفظ بيانات هذه المصروفات بنجاح.");
            }

            return Result.Failure("فشلت عملية حفظ بيانات حركة الصندوق هذه!");
        }

        //used
        public static Result Cancell(int id)
        {
            string Query = @"UPDATE CashTransactions
                SET
                    Cancelled = CASE Cancelled 
                    WHEN 0 THEN 1 
                    ELSE 1
                END
                WHERE TransactionID = @TransactionID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@TransactionID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            Result<int> result = DbManager.Current?.ExecuteNonQuery(
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
            {
                if (result.Data > 0)
                {
                    LogManager.LogInfo($"تمت عملية إلغاء حركة {id} بنجاح.");

                    return Result.Success("تمت عملية إلغاء هذه الحركة بنجاح.");
                }

                Result.Failure("لا يوجد حركات تم إلغاؤها من النظام!");
            }

            return Result.Failure("فشلت عملية إلغاء هذه الحركة!");
        }

        public static Result CancellInvoiceTransaction(
            IDbConnection con,
            IDbTransaction trans,
            int invoiceId)
        {
            string Query = @"UPDATE CashTransactions
                SET
                    Cancelled = CASE Cancelled 
                    WHEN 0 THEN 1 
                    ELSE 1
                END
                WHERE TransactionID = 
                (
                    SELECT TransactionID FROM Invoices WHERE InvoiceID = @InvoiceID
                );";

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
                return Result.Success();

            return Result.Failure("فشلت عملية إلغاء هذه الحركة!");
        }

        //used
        public static Result CancellInvoicePaymentsTransactions(
            IDbConnection con,
            IDbTransaction trans,
            int invoiceId)
        {
            string Query = @"UPDATE CashTransactions
                SET
                    Cancelled = CASE Cancelled 
                    WHEN 0 THEN 1 
                    ELSE 1
                END
                WHERE TransactionID IN
                (
                    SELECT TransactionID FROM Payments WHERE InvoiceID = @InvoiceID
                );";

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
                return Result.Success();

            return Result.Failure("فشلت عملية إلغاء حركات الدفع!");
        }

        //public static Result CancellPaymentTransaction(
        //    IDbConnection con,
        //    IDbTransaction trans,
        //    int id)
        //{
        //    string Query = @"UPDATE CashTransactions
        //        SET
        //            Cancelled = CASE Cancelled
        //            WHEN 0 THEN 1
        //            ELSE 1
        //            END
        //        WHERE TransactionID = 
        //        (
        //            SELECT TransactionID FROM Payments WHERE PaymentID = @PaymentID
        //        );";

        //    DbParameterInfo[] Parameters = new DbParameterInfo[]
        //    {
        //        new DbParameterInfo
        //        {
        //            Name = "@PaymentID",
        //            DbType = DbType.Int64,
        //            Value = id,
        //        },
        //    };

        //    Result<int> result =  DbManager.Current?.ExecuteNonQuery(
        //        con,
        //        trans,
        //        CommandType.Text, 
        //        Query, 
        //        Parameters);

        //    if (result.IsSuccess)
        //    {
        //        if (result.Data > 0)
        //            return Result.Success();

        //        return Result.Failure("لم يتم تحديث بيانات أي حركة صندوق!");
        //    }

        //    return Result.Failure("فشلت عملية إلغاء حركة الصندوق!");
        //}

        //used
        public static Result Cancell(
            IDbConnection con,
            IDbTransaction trans,
            int id)
        {
            string Query = @"UPDATE CashTransactions
                SET
                    Cancelled = CASE Cancelled
                    WHEN 0 THEN 1
                    ELSE 1
                    END
                WHERE TransactionID = @TransactionID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@TransactionID",
                    DbType = DbType.Int64,
                    Value = id,
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
                if (result.Data > 0)
                    return Result.Success();

                return Result.Failure("لم يتم تحديث بيانات أي حركة صندوق!");
            }

            return Result.Failure("فشلت عملية إلغاء حركة الصندوق!");
        }

        //used
        public static Result<bool> IsExist(int id)
        {
            string Query = @"SELECT EXISTS
                (
                    SELECT 1 FROM CashTransactions 
                    WHERE TransactionID = @TransactionID
                ) AS IsExist;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@TransactionID",
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
            string filterValue)
        {
            string Query = string.Empty;

            switch (filterMethodIndex)
            {
                case (int)FilterMethodsCash.TransactionDate:
                    Query = @"SELECT COUNT(TransactionID) FROM CashTransactions
                        WHERE TransactionDate LIKE @FilterValue || '%';";
                    break;

                case (int)FilterMethodsCash.Type:
                    Query = @"SELECT COUNT(TransactionID) FROM CashTransactions
                        WHERE TransactionType LIKE @FilterValue || '%';";
                    break;

                case (int)FilterMethodsCash.Description:
                    Query = @"SELECT COUNT(TransactionID) FROM CashTransactions
                        WHERE Description LIKE @FilterValue || '%';";
                    break;

                default:
                    Query = @"SELECT COUNT(TransactionID) FROM CashTransactions;";
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

        //used
        public static Result<DataTable> GetCashTransactions(
            int offset,
            int pageSize,
            int filterMethodIndex,
            string filterValue)
        {
            string Query = string.Empty;

            switch (filterMethodIndex)
            {
                case (int)FilterMethodsCash.TransactionDate:
                    Query = @"SELECT TransactionID, TransactionDate,
                        TransactionType, PaidAmount, Description, CreatedAt
                        Cancelled FROM CashTransactions
                        WHERE TransactionDate LIKE @FilterValue || '%'
                        ORDER BY Cancelled ASC, TransactionID DESC
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsCash.Type:
                    Query = @"SELECT TransactionID, TransactionDate,
                        TransactionType, PaidAmount, Description, CreatedAt
                        Cancelled FROM CashTransactions
                        WHERE TransactionType LIKE @FilterValue || '%'
                        ORDER BY Cancelled ASC, TransactionID DESC
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsCash.Description:
                    Query = @"SELECT TransactionID, TransactionDate,
                        TransactionType, PaidAmount, Description, CreatedAt
                        Cancelled FROM CashTransactions
                        WHERE Description LIKE '%' || @FilterValue || '%'
                        ORDER BY Cancelled ASC, TransactionID DESC
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                default:
                    Query = @"SELECT TransactionID, TransactionDate,
                        TransactionType, PaidAmount, Description, CreatedAt
                        Cancelled FROM CashTransactions
                        ORDER BY Cancelled ASC, TransactionID DESC
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

        //public static Result<bool> IsRevenue(int id)
        //{
        //    string Query = @"SELECT EXISTS
        //        (
        //            SELECT 1 FROM CashTransactions WHERE TransactionID = @TransactionID 
        //            AND TransactionType = @TransactionType
        //        ) AS IsRevenue;";

        //    DbParameterInfo[] Parameters = new DbParameterInfo[]
        //    {
        //        new DbParameterInfo
        //        {
        //            Name = "@TransactionID",
        //            DbType = DbType.Int64,
        //            Value = id,
        //        },
        //        new DbParameterInfo
        //        {
        //            Name = "@TransactionType",
        //            DbType = DbType.String,
        //            Value = TransactionType.Revenue.ToArabic(),
        //        }
        //    };

        //    return DataQueryService.Scalar<bool>(
        //        CommandType.Text,
        //        Query,
        //        Parameters);
        //}

        //used
        public static Result<decimal> GetCurrentBalance()
        {
            string Query = @"SELECT
                COALESCE(
                SUM(
                CASE
                WHEN TransactionType = @TransactionType AND Cancelled = 0
                THEN PaidAmount
                ELSE -PaidAmount
                END
                ), 0)
                FROM CashTransactions;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@TransactionType",
                    DbType = DbType.String,
                    Value = TransactionType.Revenue.ToArabic(),
                }
            };

            return DataQueryService.Scalar<decimal>(
                CommandType.Text,
                Query,
                Parameters);
        }

        //public static Result<int> GetInvoiceTransaction(int invoiceId)
        //{
        //    string Query = @"SELECT TransactionID FROM SalesInvoices
        //        WHERE InvoiceID = @InvoiceID;";

        //    DbParameterInfo[] Parameters = new DbParameterInfo[]
        //    {
        //        new DbParameterInfo
        //        {
        //            Name = "@InvoiceID",
        //            DbType = DbType.Int64,
        //            Value = invoiceId
        //        }
        //    };

        //    var result = DataQueryService.Scalar<int>(
        //        CommandType.Text,
        //        Query,
        //        Parameters);

        //    if (result.IsSuccess)
        //        return result;

        //    return Result<int>.Failure("فشلت عملية الوصول للحركة!");
        //}

        //public static Result<IEnumerable<int>> GetTransactionsPayments(int invoiceId)
        //{
        //    string Query = @"SELECT TransactionID FROM CreditPayments
        //        WHERE InvoiceID = @InvoiceID;";

        //    DbParameterInfo[] Parameters = new DbParameterInfo[]
        //    {
        //        new DbParameterInfo
        //        {
        //            Name = "@InvoiceID",
        //            DbType = DbType.Int64,
        //            Value = invoiceId,
        //        },
        //    };

        //    var result = DbManager.Current?.GetDataTable(
        //        CommandType.Text,
        //        Query,
        //        Parameters);

        //    List<int> paymentsTransactions = new List<int>();

        //    if (result.IsSuccess)
        //    {
        //        if (result.Data != null)
        //            paymentsTransactions = result.Data
        //                .AsEnumerable()
        //                .Select(r => Convert.ToInt32(r["TransactionID"]))
        //                .ToList();

        //        return Result<IEnumerable<int>>.Success(paymentsTransactions);
        //    }

        //    return Result<IEnumerable<int>>.Failure(
        //        "فشلت عملية الوصول لحركات مدفوعات هذه الفاتورة!");
        //}
    }
}

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
    public static class InvoiceData
    {
        //used
        public static Result<InvoiceModel> Find(int id)
        {
            string Query = @"SELECT * FROM Invoices WHERE InvoiceID = @InvoiceID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@InvoiceID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.FirstOrDefault<InvoiceModel>(
                CommandType.Text,
                Query, 
                Parameters);
        }

        //used
        public static Result AddNew(
            IDbConnection con,
            IDbTransaction trans,
            InvoiceModel model)
        {
            string Query = @"INSERT INTO Invoices 
                (
                    InvoiceDate,
                    InvoiceStatus,
                    PaidAmount,
                    TotalAmount,
                    TransactionID
                )
                VALUES
                (
                    @InvoiceDate,
                    @InvoiceStatus,
                    @PaidAmount,
                    @TotalAmount,
                    @TransactionID
                );

                SELECT LAST_INSERT_ROWID();";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@InvoiceDate",
                    DbType = DbType.DateTime,
                    Value = model.InvoiceDate,
                },
                new DbParameterInfo
                {
                    Name = "@InvoiceStatus",
                    DbType = DbType.String,
                    Value = model.InvoiceStatus,
                },
                new DbParameterInfo
                {
                    Name = "PaidAmount",
                    DbType = DbType.Decimal,
                    Value = model.PaidAmount,
                },
                new DbParameterInfo
                {
                    Name = "@TotalAmount",
                    DbType = DbType.Decimal,
                    Value = model.TotalAmount,
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
                model.InvoiceID = result.Data;

                return Result.Success("تمت عملية إضافة فاتورة بنجاح.");
            }

            return Result.Failure("فشلت عملية إضافة فاتورة!");
        }

        public static Result Update(
            IDbConnection con,
            IDbTransaction trans,
            InvoiceModel model)
        {
            string Query = @"UPDATE Invoices
                SET
                    InvoiceDate = @InvoiceDate
                WHERE InvoiceID = @InvoiceID;";

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
                    Name = "@InvoiceDate",
                    DbType = DbType.DateTime,
                    Value = model.InvoiceDate,
                },
            };

            Result<int> result = DbManager.Current?.ExecuteNonQuery(
                con,
                trans,
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
                return Result.Success("تمت عملية تحديث بيانات الفاتورة بنجاح.");

            return Result.Failure("فشلت عملية تحديث بيانات الفاتورة!");
        }

        //used
        public static Result UpdatePaidAmount(
            IDbConnection con,
            IDbTransaction trans,
            int invoiceId)
        {
            string Query = @"UPDATE Invoices
                SET
                    PaidAmount = 
                    (
                        SELECT SUM(PaidAmount) AS InvoicePayments FROM Payments 
                        WHERE InvoiceID = @InvoiceID AND Cancelled = 0
                    )
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
                return Result.Success();

            return Result.Failure("فشلت عملية تحديث مبلغ السداد من الفاتورة");
        }

        public static Result UpdatePaidAmountAfterCancellReturns(
            IDbConnection con,
            IDbTransaction trans,
            int invoiceId)
        {
            string Query = @"UPDATE Invoices
                SET
                    PaidAmount = TotalAmount
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
                return Result.Success();

            return Result.Failure("فشلت عملية تحديث مبلغ السداد من الفاتورة");
        }

        //used
        public static Result UpdateStatus(
            IDbConnection con,
            IDbTransaction trans,
            int invoiceId)
        {
            string Query = @"UPDATE Invoices
                SET InvoiceStatus =
                    CASE
                        WHEN PaidAmount = TotalAmount
                        THEN @Paid
                        ELSE @Deferred
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
                new DbParameterInfo
                {
                    Name = "@Paid",
                    DbType = DbType.String,
                    Value = InvoiceStatus.Paid.ToArabic()
                },
                new DbParameterInfo
                {
                    Name = "@Deferred",
                    DbType = DbType.String,
                    Value = InvoiceStatus.Deferred.ToArabic()
                }
            };

            Result<int> result = DbManager.Current?.ExecuteNonQuery(
                con,
                trans,
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
                return Result.Success();

            return Result.Failure("فشلت عملية تحديث حالة الفاتورة!");
        }

        //public static Result<string> GetInvoiceStatus(int id)
        //{
        //    string Query = @"SELECT InvoiceStatus FROM Invoices
        //        WHERE InvoiceID = @InvoiceID";

        //    DbParameterInfo[] Parameters = new DbParameterInfo[]
        //    {
        //        new DbParameterInfo
        //        {
        //            Name = "@InvoiceID",
        //            DbType = DbType.Int64,
        //            Value = id,
        //        },
        //    };

        //    return DataQueryService.Scalar<string>(
        //        CommandType.Text,
        //        Query,
        //        Parameters);
        //}

        //public static Result<DateTime> GetInvoiceDate(int invoiceId)
        //{
        //    string Query = @"SELECT InvoiceDate FROM Invoices
        //        WHERE InvoiceID = @InvoiceID;";

        //    DbParameterInfo[] Parameters = new DbParameterInfo[]
        //    {
        //        new DbParameterInfo
        //        {
        //            Name = "@InvoiceID",
        //            DbType = DbType.DateTime,
        //            Value = invoiceId,
        //        },
        //    };

        //    return DataQueryService.Scalar<DateTime>(CommandType.Text, Query, Parameters);
        //}

        //public static Result<decimal> GetRemainingAmount(int invoiceId)
        //{
        //    string Query = @"SELECT (TotalAmount - PaidAmount) AS RemainingAmount
        //        FROM Invoices WHERE InvoiceID = @InvoiceID;";

        //    DbParameterInfo[] Parameters = new DbParameterInfo[]
        //    {
        //        new DbParameterInfo
        //        {
        //            Name = "@InvoiceID",
        //            DbType = DbType.Int64,
        //            Value = invoiceId,
        //        }
        //    };

        //    return DataQueryService.Scalar<decimal>(CommandType.Text, Query, Parameters);
        //}

        //used
        public static Result<bool> HasPayments(int id)
        {
            string Query = @"SELECT EXISTS
                (
                    SELECT 1 FROM Payments WHERE InvoiceID = @InvoiceID
                ) AS IsExist;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@InvoiceID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.Scalar<bool>(
                CommandType.Text,
                Query,
                Parameters);
        }
    }
}

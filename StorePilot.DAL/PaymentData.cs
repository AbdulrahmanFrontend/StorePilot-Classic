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
    public static class PaymentData
    {
        //used
        public static Result<PaymentModel> Find(int id)
        {
            string Query = @"SELECT * FROM Payments 
                WHERE PaymentID = @PaymentID;";

            DbParameterInfo[] Paramters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@PaymentID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.FirstOrDefault<PaymentModel>(
                CommandType.Text,
                Query,
                Paramters);
        }

        //used
        public static Result AddNew(
            IDbConnection con,
            IDbTransaction trans,
            PaymentModel model)
        {
            string Query = @"INSERT INTO Payments
                (
                    InvoiceID,
                    PaymentDate,
                    PaidAmount,
                    MethodID,
                    Notes,
                    TransactionID
                )
                VALUES
                (
                    @InvoiceID,
                    @PaymentDate,
                    @PaidAmount,
                    @MethodID,
                    @Notes,
                    @TransactionID
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
                    Name = "@PaymentDate",
                    DbType = DbType.DateTime,
                    Value = model.PaymentDate,
                },
                new DbParameterInfo
                {
                    Name = "@PaidAmount",
                    DbType = DbType.Decimal,
                    Value = model.PaidAmount,
                },
                new DbParameterInfo
                {
                    Name = "@MethodID",
                    DbType = DbType.Int64,
                    Value = model.MethodID,
                },
                new DbParameterInfo
                {
                    Name = "@Notes",
                    DbType = DbType.String,
                    Value = model.Notes,
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
                model.PaymentID = result.Data;

                return Result.Success();
            }

            return Result.Failure("فشلت عملية إضافة عملية الدفع هذه!");
        }

        //used
        public static Result Cancell(
            IDbConnection con,
            IDbTransaction trans,
            int paymentId)
        {
            string Query = @"UPDATE Payments
                SET
                    Cancelled = CASE Cancelled
                    WHEN 0 THEN 1
                    ELSE 1
                END
                WHERE PaymentID = @PaymentID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@PaymentID",
                    DbType = DbType.Int64,
                    Value = paymentId,
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

            return Result.Failure("فشلت عملية إلغاء عملية الدفع هذه!");
        }

        //used
        public static Result CancellInvoicePayments(
            IDbConnection con,
            IDbTransaction trans,
            int invoiceId)
        {
            string Query = @"UPDATE Payments
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
                return Result.Success();

            return Result.Failure("فشلت عملية حذف مدفوعات هذه الفاتورة!");
        }

        //used
        public static Result<bool> IsExist(int id)
        {
            string Query = @"SELECT EXISTS
                (
                    SELECT 1 FROM Payments WHERE PaymentID = @PaymentID
                ) AS IsExist;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@PaymentID",
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
        public static Result<int> GetPaymentsInvoiceCount(
            int invoiceId,
            int filterMethodIndex,
            string filterValue)
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
                case (int)FilterMethodsPayments.PaymentID:
                    Query = @"SELECT COUNT(PaymentID) FROM view_PaymentsDetails
                        WHERE PaymentID = @FilterValue
                        AND InvoiceID = @InvoiceID;";

                    parameter = new DbParameterInfo
                    {
                        Name = "@FilterValue",
                        DbType = DbType.Int64,
                        Value = int.TryParse(filterValue?.ToString(), out int PaymentID)
                            ? PaymentID : 0,
                    };

                    break;

                case (int)FilterMethodsPayments.PaymentDate:
                    Query = @"SELECT COUNT(PaymentID) FROM view_PaymentsDetails
                        WHERE PaymentDate LIKE @FilterValue || '%'
                        AND InvoiceID = @InvoiceID;";
                    break;

                case (int)FilterMethodsPayments.PaymentMethod:
                    Query = @"SELECT COUNT(PaymentID) FROM view_PaymentsDetails
                        WHERE MethodName LIKE @FilterValue || '%'
                        AND InvoiceID = @InvoiceID;";
                    break;

                default:
                    Query = @"SELECT COUNT(PaymentID) FROM view_PaymentsDetails
                        WHERE InvoiceID = @InvoiceID;";
                    break;
            }

            List<DbParameterInfo> Parameters = new List<DbParameterInfo>
            {
                new DbParameterInfo
                {
                    Name = "@InvoiceID",
                    DbType = DbType.Int64,
                    Value = invoiceId,
                },
            };

            Parameters.Add(parameter);

            return DataQueryService.Scalar<int>(
                CommandType.Text,
                Query,
                Parameters);
        }

        //used
        public static Result<DataTable> GetPaymentsInvoice(
            int invoiceId,
            int offset,
            int pageSize,
            int filterMethodIndex,
            string filterValue)
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
                case (int)FilterMethodsPayments.PaymentID:
                    Query = @"SELECT PaymentID, InvoiceID, PaymentDate, PaidAmount,
                        MethodName, Cancelled FROM Payments
                        WHERE PaymentID = @FilterValue
                        AND InvoiceID = @InvoiceID
                        LIMIT @PageSize
                        OFFSET @Offset;";

                    parameter = new DbParameterInfo
                    {
                        Name = "@FilterValue",
                        DbType = DbType.Int64,
                        Value = int.TryParse(filterValue?.ToString(), out int PaymentID)
                            ? PaymentID : 0,
                    };

                    break;

                case (int)FilterMethodsPayments.PaymentDate:
                    Query = @"SELECT PaymentID, InvoiceID, PaymentDate, PaidAmount,
                        MethodName, Cancelled FROM Payments
                        WHERE PaymentDate LIKE @FilterValue || '%'
                        AND InvoiceID = @InvoiceID
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsPayments.PaymentMethod:
                    Query = @"SELECT PaymentID, InvoiceID, PaymentDate, PaidAmount,
                        MethodName, Cancelled FROM Payments
                        WHERE MethodName LIKE @FilterValue || '%'
                        AND InvoiceID = @InvoiceID
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                default:
                    Query = @"SELECT PaymentID, InvoiceID, PaymentDate, PaidAmount,
                        MethodName, Cancelled FROM Payments
                        WHERE InvoiceID = @InvoiceID
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;
            }

            List<DbParameterInfo> Parameters = new List<DbParameterInfo>
            {
                new DbParameterInfo
                {
                    Name = "@InvoiceID",
                    DbType = DbType.Int64,
                    Value = invoiceId,
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

            Parameters.Add(parameter);

            return DbManager.Current?.GetDataTable(
                CommandType.Text,
                Query,
                Parameters);
        }

        //used
        public static Result<bool> IsForSales(int invoiceId)
        {
            string Query = @"SELECT EXISTS
                (
                    SELECT 1 FROM SalesInvoices WHERE InvoiceID = @InvoiceID
                ) AS IsForSales;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@InvoiceID",
                    DbType = DbType.Int64,
                    Value = invoiceId,
                },
            };

            return DataQueryService.Scalar<bool>(CommandType.Text, Query, Parameters);
        }
    }
}

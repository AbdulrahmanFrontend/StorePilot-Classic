using DevToolkit.Core.Results;
using DevToolkit.Data;
using DevToolkit.Data.Core;
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
                    Value = model.InvoiceDate,
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
    }
}

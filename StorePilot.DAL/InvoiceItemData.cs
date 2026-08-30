using DevToolkit.Core.Results;
using DevToolkit.Data;
using DevToolkit.Data.Core;
using StorePilot.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.DAL
{
    public static class InvoiceItemData
    {
        //used
        public static Result AddNew(
            IDbConnection con,
            IDbTransaction trans,
            InvoiceItemModel model)
        {
            string Query = @"INSERT INTO InvoicesItems
                (
                    InvoiceID,
                    ProductID,
                    Quantity, 
                    UnitPrice
                )
                VALUES
                (
                    @InvoiceID,
                    @ProductID,
                    @Quantity,
                    @UnitPrice
                );";

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
                    Name = "@ProductID",
                    DbType = DbType.Int64,
                    Value = model.ProductID,
                },
                new DbParameterInfo
                {
                    Name = "@Quantity",
                    DbType = DbType.Decimal,
                    Value = model.Quantity,
                },
                new DbParameterInfo
                { Name = "@UnitPrice",
                    DbType = DbType.Decimal,
                    Value = model.UnitPrice,
                },
            };

            var result = DbManager.Current?.ExecuteNonQuery(
                con,
                trans,
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
                return Result.Success();

            return Result.Failure("فشلت عملية إضافة عنصر للفاتورة!");
        }

        //used
        public static Result<DataTable> GetInvoiceItems(int invoiceId)
        {
            string Query = @"SELECT * FROM view_InvoicesItemsDetails
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

            return DbManager.Current?.GetDataTable(
                CommandType.Text,
                Query,
                Parameters);
        }
        
        //used
        public static Result<InvoiceItemModel> GetSaleInvoiceItem(
            int saleInvoiceId,
            int productId)
        {
            string Query = @"SELECT * FROM InvoicesItems 
                WHERE InvoiceID = 
                (
                    SELECT InvoiceID FROM SalesInvoices 
                    WHERE SaleInvoiceID = @SaleInvoiceID
                ) 
                AND ProductID = @ProductID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@SaleInvoiceID",
                    DbType = DbType.Int64,
                    Value = saleInvoiceId,
                },
                new DbParameterInfo
                {
                    Name = "@ProductID",
                    DbType = DbType.Int64,
                    Value = productId,
                },
            };

            return DataQueryService.FirstOrDefault<InvoiceItemModel>(
                CommandType.Text, 
                Query,
                Parameters);
        }

        //used
        public static Result UpdateInvoiceItemsAfterAddNewReturns(
            IDbConnection con,
            IDbTransaction trans,
            int returnId,
            int invoiceId)
        {
            string Query = @"UPDATE InvoicesItems
                SET Quantity = InvoicesItems.Quantity - SRI.Quantity
                FROM SalesReturnItems AS SRI
                WHERE SRI.ReturnID = @ReturnID
                  AND InvoicesItems.InvoiceID = @InvoiceID
                  AND InvoicesItems.ProductID = SRI.ProductID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@ReturnID",
                    DbType = DbType.Int64,
                    Value = returnId,
                },
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

            if (result.IsSuccess && result.Data > 0)
                return Result.Success();

            return Result.Failure("فشلت عملية تحديث عناصر الفاتورة!");
        }

        //used
        public static Result UpdateInvoiceItemsAfterCancellReturns(
            IDbConnection con,
            IDbTransaction trans,
            int returnId,
            int invoiceId)
        {
            string Query = @"UPDATE InvoicesItems
                SET Quantity = InvoicesItems.Quantity + SRI.Quantity
                FROM SalesReturnItems AS SRI
                WHERE SRI.ReturnID = @ReturnID
                  AND InvoicesItems.InvoiceID = @InvoiceID
                  AND InvoicesItems.ProductID = SRI.ProductID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@ReturnID",
                    DbType = DbType.Int64,
                    Value = returnId,
                },
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

            if (result.IsSuccess && result.Data > 0)
                return Result.Success();

            return Result.Failure("فشلت عملية تحديث عناصر الفاتورة!");
        }
    }
}

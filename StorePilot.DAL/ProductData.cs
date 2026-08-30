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
    public static class ProductData
    {
        //used
        public static Result<ProductModel> Find(int id)
        {
            string Query = @"SELECT * FROM Products 
                WHERE ProductID = @ProductID;";

            DbParameterInfo[] Paramters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@ProductID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.FirstOrDefault<ProductModel>(
                CommandType.Text,
                Query,
                Paramters);
        }

        //used
        public static Result AddNew(ProductModel model)
        {
            string Query = @"INSERT INTO Products 
            (
                ProductName, 
                BarCode, 
                UnitID,
                GroupID, 
                Quantity,
                MinQuantity, 
                PurchasePrice,
                SalePrice,
                Notes
            )
            VALUES 
            (
                @ProductName, 
                @BarCode, 
                @UnitID,
                @GroupID, 
                @Quantity,
                @MinQuantity, 
                @PurchasePrice,
                @SalePrice,
                @Notes
            );

            SELECT LAST_INSERT_ROWID();";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@ProductName",
                    DbType = DbType.String,
                    Value = model.ProductName,
                },
                new DbParameterInfo
                {
                    Name = "@BarCode",
                    DbType = DbType.String,
                    Value = model.BarCode,
                },
                new DbParameterInfo
                {
                    Name = "@GroupID",
                    DbType = DbType.Int64,
                    Value = model.GroupID,
                },
                new DbParameterInfo
                {
                    Name = "@UnitID",
                    DbType = DbType.Int64,
                    Value = model.UnitID,
                },
                new DbParameterInfo
                {
                    Name = "@MinQuantity",
                    DbType = DbType.Decimal,
                    Value = model.MinQuantity,
                },
                new DbParameterInfo
                {
                    Name = "@Quantity",
                    DbType = DbType.Decimal,
                    Value = model.Quantity,
                },
                new DbParameterInfo
                {
                    Name = "@PurchasePrice",
                    DbType = DbType.Decimal,
                    Value = model.PurchasePrice,
                },
                new DbParameterInfo
                {
                    Name = "@SalePrice",
                    DbType = DbType.Decimal,
                    Value = model.SalePrice,
                },
                new DbParameterInfo
                {
                    Name = "@Notes",
                    DbType = DbType.String,
                    Value = model.Notes,
                },
            };

            Result<int> result = DataQueryService.Scalar<int>(
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
            {
                if (result.Data > 0)
                {
                    model.ProductID = result.Data;

                    LogManager.LogInfo(
                        $"تمت عملية إضافة صنف جديد {model.ProductID} بنجاح.");

                    return Result.Success("تمت عملية حفظ بيانات هذا الصنف بنجاح.");
                }
            }

            return Result.Failure("فشلت عملية حفظ بيانات هذا الأصناف!");
        }

        //used
        public static Result Update(ProductModel model)
        {
            string Query = @"Update Products
            SET 
                ProductName = @ProductName, BarCode = @BarCode,
                GroupID = @GroupID, MinQuantity = @MinQuantity, 
                PurchasePrice = @PurchasePrice, SalePrice = @SalePrice, 
                Active = @Active, Notes = @Notes
            WHERE ProductID = @ProductID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@ProductID",
                    DbType = DbType.Int64,
                    Value = model.ProductID,
                },
                new DbParameterInfo
                {
                    Name = "@ProductName",
                    DbType = DbType.String,
                    Value = model.ProductName,
                },
                new DbParameterInfo
                {
                    Name = "@BarCode",
                    DbType = DbType.String,
                    Value = model.BarCode,
                },
                new DbParameterInfo
                {
                    Name = "@GroupID",
                    DbType = DbType.Int64,
                    Value = model.GroupID,
                },
                new DbParameterInfo
                {
                    Name = "@MinQuantity",
                    DbType = DbType.Decimal,
                    Value = model.MinQuantity,
                },
                new DbParameterInfo
                {
                    Name = "@PurchasePrice",
                    DbType = DbType.Decimal,
                    Value = model.PurchasePrice,
                },
                new DbParameterInfo
                {
                    Name = "@SalePrice",
                    DbType = DbType.Decimal,
                    Value = model.SalePrice,
                },
                new DbParameterInfo
                {
                    Name = "@Active",
                    DbType = DbType.Boolean,
                    Value = model.Active,
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
                if (result.Data > 0)
                {
                    LogManager.LogInfo(
                        $"تمت عملية تحديث بيانات صنف {model.ProductID} بنجاح.");
                    return Result.Success("تمت عملية حفظ بيانات هذا الصنف بنجاح.");
                }

                return Result.Failure("لم يتم تحديث بيانات أي صنف!");
            }

            return Result.Failure("فشلت عملية حفظ بيانات هذا الصنف!");
        }

        //used
        public static Result IncreaseStock(
            IDbConnection con,
            IDbTransaction trans,
            int invoiceId)
        {
            string Query = @"UPDATE Products
                SET Quantity = Products.Quantity + II.Quantity
                FROM InvoicesItems AS II
                WHERE II.InvoiceID = @InvoiceID
                  AND Products.ProductID = II.ProductID;";

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

            return Result.Failure("فشلت عملية زيادة المخزن!");
        }

        //used
        public static Result IncreaseStockAfterReturns(
            IDbConnection con,
            IDbTransaction trans,
            int returnId)
        {
            string Query = @"UPDATE Products
                SET Quantity = Products.Quantity + SRI.Quantity
                FROM SalesReturnItems AS SRI
                WHERE SRI.ReturnID = @ReturnID
                  AND Products.ProductID = SRI.ProductID;";

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
            {
                if (result.Data > 0)
                    return Result.Success();

                return Result.Failure("لم تحديث مخزن أي صنف!");
            }

            return Result.Failure("فشلت عملية تحديث مخزن صنف!");
        }

        //used
        public static Result DecreaseStock(
            IDbConnection con,
            IDbTransaction trans,
            int invoiceId)
        {
            string Query = @"UPDATE Products
                SET Quantity = Products.Quantity - II.Quantity
                FROM InvoicesItems AS II
                WHERE II.InvoiceID = @InvoiceID
                  AND Products.ProductID = II.ProductID;";

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

            return Result.Failure($"فشلت عملية إنقاص المخزن!");
        }

        //used
        public static Result DecreaseStockAfterCancellReturns(
            IDbConnection con,
            IDbTransaction trans,
            int returnId)
        {
            string Query = @"UPDATE Products
                SET Quantity = Products.Quantity - SRI.Quantity
                FROM SalesReturnItems AS SRI
                WHERE SRI.ReturnID = @ReturnID
                  AND Products.ProductID = SRI.ProductID;";

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
            {
                if (result.Data > 0)
                    return Result.Success();

                return Result.Failure("لم تحديث مخزن أي صنف!");
            }

            return Result.Failure("فشلت عملية تحديث مخزن صنف!");
        }

        //used
        public static Result DecreaseStockAfterCancellInvoiceReturns(
            IDbConnection con,
            IDbTransaction trans,
            int saleInvoiceId)
        {
            string Query = @"UPDATE Products
                SET Quantity = Products.Quantity - SRI_Totals.TotalReturned
                FROM (
                    SELECT SRI.ProductID, SUM(SRI.Quantity) AS TotalReturned
                    FROM SalesReturnItems SRI
                    JOIN SalesReturns SR ON SRI.ReturnID = SR.ReturnID
                    WHERE SR.SaleInvoiceID = @SaleInvoiceID
                      AND SR.Cancelled = 0
                    GROUP BY SRI.ProductID
                ) AS SRI_Totals
                WHERE Products.ProductID = SRI_Totals.ProductID;";

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

            return Result.Failure("فشلت عملية تحديث مخزن صنف!");
        }

        //used
        public static Result<bool> IsExist(int id)
        {
            string Query = @"SELECT EXISTS
                (
                    SELECT 1 FROM Products WHERE ProductID = @ProductID
                ) AS IsExist;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@ProductID",
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
            bool active)
        {
            string Query = string.Empty;

            switch (filterMethodIndex)
            {
                case (int)FilterMethodsProducts.ProductName:
                    Query = @"SELECT COUNT(ProductID) FROM view_ProductsDetails
                        WHERE ProductName LIKE @FilterValue || '%'
                        AND Active = @Active;";
                    break;

                case (int)FilterMethodsProducts.Unit:
                    Query = @"SELECT COUNT(ProductID) FROM view_ProductsDetails
                        WHERE UnitName LIKE @FilterValue || '%'
                        AND Active = @Active;";
                    break;

                case (int)FilterMethodsProducts.Group:
                    Query = @"SELECT COUNT(ProductID) FROM view_ProductsDetails
                        WHERE GroupName LIKE @FilterValue || '%'
                        AND Active = @Active;";
                    break;

                case (int)FilterMethodsProducts.BarCode:
                    Query = @"SELECT COUNT(ProductID) FROM view_ProductsDetails
                        WHERE BarCode LIKE @FilterValue || '%'
                        AND Active = @Active;";
                    break;

                default:
                    Query = @"SELECT COUNT(ProductID) FROM view_ProductsDetails
                        WHERE Active = @Active;";
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
                    Name = "@Active",
                    DbType = DbType.Boolean,
                    Value = active,
                },
            };

            return DataQueryService.Scalar<int>(
                CommandType.Text,
                Query,
                Parameters);
        }

        //used
        public static Result<DataTable> GetForSelection()
        {
            string Query = @"SELECT ProductID, ProductName FROM Products
                WHERE Active = 1;";

            return DbManager.Current?.GetDataTable(CommandType.Text, Query);
        }

        //used
        public static Result<DataTable> GetProducts(
            int offset,
            int pageSize,
            int filterMethodIndex,
            string filterValue,
            bool active)
        {
            string Query = string.Empty;

            switch (filterMethodIndex)
            {
                case (int)FilterMethodsProducts.ProductName:
                    Query = @"SELECT ProductID, ProductName, BarCode, GroupName,
                        UnitName, SalePrice, PurchasePrice, Quantity, MinQuantity, 
                        CreatedAt, Active FROM view_ProductsDetails
                        WHERE ProductName LIKE @FilterValue || '%'
                        AND Active = @Active
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsProducts.Unit:
                    Query = @"SELECT ProductID, ProductName, BarCode, GroupName,
                        UnitName, SalePrice, PurchasePrice, Quantity, MinQuantity, 
                        CreatedAt, Active FROM view_ProductsDetails
                        WHERE UnitName LIKE @FilterValue || '%'
                        AND Active = @Active
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsProducts.Group:
                    Query = @"SELECT ProductID, ProductName, BarCode, GroupName,
                        UnitName, SalePrice, PurchasePrice, Quantity, MinQuantity, 
                        CreatedAt, Active FROM view_ProductsDetails
                        WHERE GroupName LIKE @FilterValue || '%'
                        AND Active = @Active
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsProducts.BarCode:
                    Query = @"SELECT ProductID, ProductName, BarCode, GroupName,
                        UnitName, SalePrice, PurchasePrice, Quantity, MinQuantity, 
                        CreatedAt, Active FROM view_ProductsDetails
                        WHERE BarCode LIKE @FilterValue || '%'
                        AND Active = @Active
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                default:
                    Query = @"SELECT ProductID, ProductName, BarCode, GroupName,
                        UnitName, SalePrice, PurchasePrice, Quantity, MinQuantity, 
                        CreatedAt, Active FROM view_ProductsDetails
                        WHERE Active = @Active
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
                },
                new DbParameterInfo
                {
                    Name = "@Active",
                    DbType = DbType.Boolean,
                    Value = active,
                },
            };

            return DbManager.Current?.GetDataTable(
                CommandType.Text,
                Query,
                Parameters);
        }

        //used
        public static Result<bool> IsBarCodeExist(string barCode, int id)
        {
            string Query = @"SELECT EXISTS
                (
                SELECT 1 FROM Products 
                WHERE BarCode = @BarCode AND ProductID != @ProductID
                ) AS IsBarCodeExist;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@BarCode",
                    DbType = DbType.String,
                    Value = barCode,
                },
                new DbParameterInfo
                {
                    Name = "@ProductID",
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
        public static Result<bool> IsProductNameExist(string productName, int id)
        {
            string Query = @"SELECT EXISTS
                (
                SELECT 1 FROM Products 
                WHERE ProductName = @ProductName AND ProductID != @ProductID
                ) AS IsProductNameExist;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@ProductName",
                    DbType = DbType.String,
                    Value = productName,
                },
                new DbParameterInfo
                {
                    Name = "@ProductID",
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

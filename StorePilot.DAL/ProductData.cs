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
        public static Result<ProductModel> GetByID(int id)
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

        public static Result AddNew(ProductModel model)
        {
            string Query = @"INSERT INTO Products 
            (
                ProductName, 
                BarCode, 
                UnitID,
                GroupID, 
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
                @MinQuantity, 
                @PurchasePrice,
                @SalePrice,
                @Notes
            );

            SELECT last_insert_rowid();";

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

        public static Result Update(ProductModel model)
        {
            string Query = @"Update Products
            SET 
                ProductName = @ProductName, BarCode = @BarCode,
                UnitID = @UnitID, GroupID = @GroupID, 
                Quantity = @Quantity, MinQuantity = @MinQuantity, 
                PurchasePrice = @PurchasePrice, SalePrice = @SalePrice, 
                Notes = @Notes
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
                    Name = "@UnitID",
                    DbType = DbType.Int64,
                    Value = model.UnitID,
                },
                new DbParameterInfo
                {
                    Name = "@Quantity",
                    DbType = DbType.Decimal,
                    Value = model.Quantity,
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

        public static Result IncreaseStock(
            IDbConnection con,
            IDbTransaction trans,
            int purchaseId)
        {
            string Query = @"UPDATE Products
                SET Quantity =
                (
                    Quantity +
                    (
                        SELECT Quantity
                        FROM InvoicesItems
                        WHERE InvoicesItems.ProductID = Products.ProductID
                        AND InvoicesItems.InvoiceID = @InvoiceID
                    )
                )
                WHERE ProductID IN
                (
                    SELECT ProductID
                    FROM InvoicesItems
                    WHERE InvoiceID = @InvoiceID
                );";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@InvoiceID",
                    DbType = DbType.Int64,
                    Value = purchaseId,
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

        public static Result DecreaseStock(
            IDbConnection con,
            IDbTransaction trans,
            int invoiceId)
        {
            string Query = @"UPDATE Products
                SET Quantity =
                (
                    Quantity -
                    (
                        SELECT Quantity FROM InvoicesItems
                        WHERE InvoicesItems.ProductID = Products.ProductID
                        AND InvoicesItems.InvoiceID = @InvoiceID
                    )
                )
                WHERE ProductID IN
                (
                    SELECT ProductID FROM InvoicesItems
                    WHERE InvoiceID = @InvoiceID
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

            return Result.Failure($"فشلت عملية إنقاص المخزن!");
        }

        public static Result Activate(int id)
        {
            string Query = @"UPDATE Products
                SET 
                    Active = CASE Active
                    WHEN 0 THEN 1
                    ELSE 1
                END
                WHERE ProductID = @ProductID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@ProductID",
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
                    LogManager.LogInfo($"تمت عملية تفعيل صنف {id} بنجاح.");

                    return Result.Success("تمت عملية تفعيل هذا الصنف بنجاح.");
                }

                return Result.Failure("لم يتم تفعيل أي صنف في النظام!");
            }

            return Result.Failure("فشلت عملية تفعيل هذا الصنف!");
        }

        public static Result Deactivate(int id)
        {
            string Query = @"UPDATE Products
                SET 
                    Active = CASE Active
                    WHEN 1 THEN 0
                    ELSE 0
                END
                WHERE ProductID = @ProductID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@ProductID",
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
                    LogManager.LogInfo($"تمت عملية تعطيل صنف {id} بنجاح.");

                    return Result.Success("تمت عملية تعطيل هذا الصنف بنجاح.");
                }

                return Result.Failure("لم يتم تعطيل أي صنف في النظام!");
            }

            return Result.Failure("فشلت عملية تعطيل هذا الصنف!");
        }

        public static Result<bool> IsFound(int id)
        {
            string Query = @"SELECT EXISTS
                (
                    SELECT 1 FROM Products WHERE ProductID = @ProductID
                ) AS IsFound;";

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

        public static Result<bool> IsActive(int id)
        {
            string Query = @"SELECT Active FROM Products 
                WHERE ProductID = @ProductID;";

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

        public static Result<int> GetCount()
        {
            string Query = "SELECT COUNT(ProductID) AS ProductsCount FROM Products;";

            return DataQueryService.Scalar<int>(CommandType.Text, Query);
        }

        public static Result<DataTable> GetLowStockProducts()
        {
            string Query = @"SELECT ProductName, Quantity, MinQuantity FROM Products
                ORDER BY ProductID ASC, Quantity - MinQuantity ASC
                LIMIT 10;";

            return DbManager.Current.GetDataTable(CommandType.Text, Query);
        }

        public static Result<int> GetCount(
            int filterMethodIndex,
            string filterValue)
        {
            string Query = string.Empty;

            switch (filterMethodIndex)
            {
                case (int)FilterMethodsProducts.ProductName:
                    Query = @"SELECT COUNT(ProductID) FROM view_ProductsDetails
                        WHERE ProductName LIKE @FilterValue || '%';";
                    break;

                case (int)FilterMethodsProducts.Unit:
                    Query = @"SELECT COUNT(ProductID) FROM view_ProductsDetails
                        WHERE UnitName LIKE @FilterValue || '%';";
                    break;

                case (int)FilterMethodsProducts.Group:
                    Query = @"SELECT COUNT(ProductID) FROM view_ProductsDetails
                        WHERE GroupName LIKE @FilterValue || '%';";
                    break;

                case (int)FilterMethodsProducts.BarCode:
                    Query = @"SELECT COUNT(ProductID) FROM view_ProductsDetails
                        WHERE BarCode LIKE @FilterValue || '%';";
                    break;

                default:
                    Query = @"SELECT COUNT(ProductID) FROM view_ProductsDetails;";
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

        public static Result<DataTable> GetForSelection()
        {
            string Query = @"SELECT ProductID, ProductName FROM Products
                WHERE Active = 1;";

            return DbManager.Current?.GetDataTable(CommandType.Text, Query);
        }

        public static Result<DataTable> GetProducts(
            int offset,
            int pageSize,
            int filterMethodIndex,
            string filterValue)
        {
            string Query = string.Empty;

            switch (filterMethodIndex)
            {
                case (int)FilterMethodsProducts.ProductName:
                    Query = @"SELECT ProductID, ProductName, BarCode, GroupName,
                        UnitName, SalePrice, PurchasePrice, Quantity, MinQuantity, 
                        CreatedAt, Active FROM view_ProductsDetails
                        WHERE ProductName LIKE @FilterValue || '%'
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsProducts.Unit:
                    Query = @"SELECT ProductID, ProductName, BarCode, GroupName,
                        UnitName, SalePrice, PurchasePrice, Quantity, MinQuantity, 
                        CreatedAt, Active FROM view_ProductsDetails
                        WHERE UnitName LIKE @FilterValue || '%'
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsProducts.Group:
                    Query = @"SELECT ProductID, ProductName, BarCode, GroupName,
                        UnitName, SalePrice, PurchasePrice, Quantity, MinQuantity, 
                        CreatedAt, Active FROM view_ProductsDetails
                        WHERE GroupName LIKE @FilterValue || '%'
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsProducts.BarCode:
                    Query = @"SELECT ProductID, ProductName, BarCode, GroupName,
                        UnitName, SalePrice, PurchasePrice, Quantity, MinQuantity, 
                        CreatedAt, Active FROM view_ProductsDetails
                        WHERE BarCode LIKE @FilterValue || '%'
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                default:
                    Query = @"SELECT ProductID, ProductName, BarCode, GroupName,
                        UnitName, SalePrice, PurchasePrice, Quantity, MinQuantity, 
                        CreatedAt, Active FROM view_ProductsDetails
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

        public static Result<bool> IsBarCodeFound(string barCode, int id)
        {
            string Query = @"SELECT EXISTS
                (
                SELECT 1 FROM Products 
                WHERE BarCode = @BarCode AND ProductID != @ProductID
                ) AS IsBarCodeFound;";

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

        public static Result<bool> IsProductNameFound(string productName, int id)
        {
            string Query = @"SELECT EXISTS
                (
                SELECT 1 FROM Products 
                WHERE ProductName = @ProductName AND ProductID != @ProductID
                ) AS IsProductNameFound;";

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

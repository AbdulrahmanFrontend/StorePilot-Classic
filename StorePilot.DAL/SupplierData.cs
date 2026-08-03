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
    public static class SupplierData
    {
        //used
        public static Result<SupplierModel> Find(int ID)
        {
            string Query = @"SELECT * FROM view_SuppliersDetails 
                WHERE SupplierID = @SupplierID;";

            DbParameterInfo[] Paramters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@SupplierID",
                    DbType = DbType.Int64,
                    Value = ID,
                },
            };

            return DataQueryService.FirstOrDefault<SupplierModel>(
                CommandType.Text,
                Query,
                Paramters);
        }

        //used
        public static Result AddNew(
            IDbConnection con,
            IDbTransaction trans,
            SupplierModel newSupplier)
        {
            string Query = @"INSERT INTO Suppliers (PersonID, Notes)
                VALUES (@PersonID, @Notes);

                SELECT LAST_INSERT_ROWID();";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@PersonID",
                    DbType = DbType.Int64,
                    Value = newSupplier.PersonID,
                },
                new DbParameterInfo
                {
                    Name = "@Notes",
                    DbType = DbType.String,
                    Value = newSupplier.Notes,
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
                newSupplier.SupplierID = result.Data;

                return Result.Success("تمت عملية إضافة هذا المورد للنظام بنجاح.");
            }

            return Result.Failure("فشلت عملية إضافة هذا المورد للنظام!");
        }

        //used
        public static Result Update(
            IDbConnection con,
            IDbTransaction trans,
            SupplierModel supplier)
        {
            string Query = @"UPDATE Suppliers
                SET 
                    Active = @Active, Notes = @Notes
                WHERE SupplierID = @SupplierID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@SupplierID",
                    DbType = DbType.Int64,
                    Value = supplier.SupplierID,
                },
                new DbParameterInfo
                {
                    Name = "@Active",
                    DbType = DbType.Boolean,
                    Value = supplier.Active,
                },
                new DbParameterInfo
                {
                    Name = "@Notes",
                    DbType = DbType.String,
                    Value = supplier.Notes,
                },
            };

            Result<int> result = DbManager.Current?.ExecuteNonQuery(
                con,
                trans,
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
                return Result.Success("تمت عملية تحديث بيانات هذا المورد بنجاح.");

            return Result.Failure("فشلت عملية تحديث بيانات هذا المورد!");
        }

        //used
        public static Result<bool> IsExist(int id)
        {
            string Query = @"SELECT EXISTS
                (
                    SELECT 1 FROM view_SuppliersDetails WHERE SupplierID = @SupplierID
                ) AS IsExist;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@SupplierID",
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
        public static Result<int> GetCount()
        {
            string Query = "SELECT COUNT(SupplierID) FROM view_SuppliersDetails;";

            return DataQueryService.Scalar<int>(CommandType.Text, Query);
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
                case (int)FilterMethodsPeople.Name:
                    Query = @"SELECT COUNT(SupplierID) FROM view_SuppliersDetails
                        WHERE Name LIKE @FilterValue || '%'
                        AND Active = @Active;";
                    break;

                case (int)FilterMethodsPeople.Phone:
                    Query = @"SELECT COUNT(SupplierID) FROM view_SuppliersDetails
                        WHERE Phone LIKE @FilterValue || '%'
                        AND Active = @Active;";
                    break;

                case (int)FilterMethodsPeople.Address:
                    Query = @"SELECT COUNT(SupplierID) FROM view_SuppliersDetails
                        WHERE Address LIKE @FilterValue || '%'
                        AND Active = @Active;";
                    break;

                default:
                    Query = @"SELECT COUNT(*) FROM view_SuppliersDetails
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
        public static Result<DataTable> GetSuppliers(
            int offset,
            int pageSize,
            int filterMethodIndex,
            string filterValue,
            bool active)
        {
            string Query = string.Empty;

            switch (filterMethodIndex)
            {
                case (int)FilterMethodsPeople.Name:
                    Query = @"SELECT SupplierID, Name, Phone, Address,
                        CreatedAt, Active FROM view_SuppliersDetails
                        WHERE Name LIKE @FilterValue || '%'
                        AND Active = @Active
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsPeople.Phone:
                    Query = @"SELECT SupplierID, Name, Phone, Address,
                        CreatedAt, Active FROM view_SuppliersDetails
                        WHERE Phone LIKE @FilterValue || '%'
                        AND Active = @Active
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsPeople.Address:
                    Query = @"SELECT SupplierID, Name, Phone, Address,
                        CreatedAt, Active FROM view_SuppliersDetails
                        WHERE Address LIKE @FilterValue || '%'
                        AND Active = @Active
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                default:
                    Query = @"SELECT SupplierID, Name, Phone, Address,
                        CreatedAt, Active FROM view_SuppliersDetails
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
                }
            };

            return DbManager.Current?.GetDataTable(
                CommandType.Text,
                Query,
                Parameters);
        }

        //used
        public static Result<DataTable> GetForSelection()
        {
            string Query = @"SELECT Name, SupplierID 
                FROM view_SuppliersDetails
                WHERE Active = 1
                ORDER BY SupplierID ASC;";

            return DbManager.Current?.GetDataTable(CommandType.Text, Query);
        }
    }
}

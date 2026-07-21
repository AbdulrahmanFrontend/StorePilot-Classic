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
        public static Result<SupplierModel> GetByID(int ID)
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

        public static Result AddNew(
            IDbConnection con,
            IDbTransaction trans,
            SupplierModel newSupplier)
        {
            string Query = @"INSERT INTO Suppliers (PersonID, Notes)
                VALUES (@PersonID, @Notes);

                SELECT last_insert_rowid();";

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

        public static Result Update(
            IDbConnection con,
            IDbTransaction trans,
            SupplierModel supplier)
        {
            string Query = @"UPDATE Suppliers
                SET 
                    Notes = @Notes
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
                    Name = "@Notes",
                    DbType = DbType.String,
                    Value = supplier.Notes,
                }
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

        public static Result Activate(int id)
        {
            string Query = @"UPDATE Suppliers
                SET Active = CASE Active
                    WHEN 1 THEN 0
                    ELSE 1
                END
                WHERE SupplierID = @SupplierID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@SupplierID",
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
                    LogManager.LogInfo($"تمت عملية تفعيل / تعطيل هذا المورد {id} بنجاح.");
                    return Result.Success("تمت عملية تفعيل / تعطيل هذا المورد بنجاح.");
                }

                return Result.Failure("لم يتم تحديث بيانات أي مورد!");
            }

            return Result.Failure("فشلت عملية تفعيل / تعطيل هذا المورد!");
        }

        public static Result<bool> IsFound(int id)
        {
            string Query = @"SELECT EXISTS
                (
                    SELECT 1 FROM Suppliers WHERE SupplierID = @SupplierID
                ) 
                AS IsFound;";

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

        public static Result<int> GetCount()
        {
            string Query = "SELECT COUNT(SupplierID) FROM Suppliers;";

            return DataQueryService.Scalar<int>(CommandType.Text, Query);
        }

        public static Result<int> GetCount(
            int filterMethodIndex,
            string filterValue)
        {
            string Query = string.Empty;

            switch (filterMethodIndex)
            {
                case (int)FilterMethodsPeople.Name:
                    Query = @"SELECT COUNT(SupplierID) FROM view_SuppliersDetails
                        WHERE Name LIKE @FilterValue || '%';";
                    break;

                case (int)FilterMethodsPeople.Phone:
                    Query = @"SELECT COUNT(SupplierID) FROM view_SuppliersDetails
                        WHERE PhoneNumber LIKE @FilterValue || '%';";
                    break;

                case (int)FilterMethodsPeople.Address:
                    Query = @"SELECT COUNT(SupplierID) FROM view_SuppliersDetails
                        WHERE Address LIKE @FilterValue || '%';";
                    break;

                default:
                    Query = @"SELECT COUNT(*) FROM view_SuppliersDetails;";
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

        public static Result<DataTable> GetSuppliers(
            int offset,
            int pageSize,
            int filterMethodIndex,
            string filterValue)
        {
            string Query = string.Empty;

            switch (filterMethodIndex)
            {
                case (int)FilterMethodsPeople.Name:
                    Query = @"SELECT SupplierID, Name, Phone, Address,
                        CreatedAt, Active FROM view_SuppliersDetails
                        WHERE Name LIKE @FilterValue || '%'
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsPeople.Phone:
                    Query = @"SELECT SupplierID, Name, Phone, Address,
                        CreatedAt, Active FROM view_SuppliersDetails
                        WHERE Phone LIKE @FilterValue || '%'
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsPeople.Address:
                    Query = @"SELECT SupplierID, Name, Phone, Address,
                        CreatedAt, Active FROM view_SuppliersDetails
                        WHERE Address LIKE @FilterValue || '%'
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                default:
                    Query = @"SELECT SupplierID, Name, Phone, Address,
                        CreatedAt, Active FROM view_SuppliersDetails
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

        public static Result<DataTable> GetForSelection()
        {
            string Query = @"SELECT Name, SupplierID 
                FROM view_SuppliersDetails
                ORDER BY SupplierID ASC;";

            return DbManager.Current?.GetDataTable(CommandType.Text, Query);
        }
    }
}

using DevToolkit.Core.Results;
using DevToolkit.Data;
using DevToolkit.Data.Core;
using DevToolkit.Logging.Managers;
using Microsoft.SqlServer.Server;
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
    public static class CustomerData
    {
        //used
        public static Result<CustomerModel> Find(int id)
        {
            string Query = @"SELECT * FROM view_CustomersDetails 
                WHERE CustomerID = @CustomerID;";

            DbParameterInfo[] Paramters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@CustomerID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.FirstOrDefault<CustomerModel>(
                CommandType.Text,
                Query,
                Paramters);
        }

        //used
        public static Result AddNew(
            IDbConnection con,
            IDbTransaction trans,
            CustomerModel newCustomer)
        {
            string Query = @"INSERT INTO Customers (PersonID, Notes)
                VALUES (@PersonID, @Notes);

                SELECT LAST_INSERT_ROWID();";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@PersonID",
                    DbType = DbType.Int64,
                    Value = newCustomer.PersonID,
                },
                new DbParameterInfo
                {
                    Name = "@Notes",
                    DbType = DbType.String,
                    Value = newCustomer.Notes,
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
                newCustomer.CustomerID = result.Data;

                return Result.Success("تمت عملية إضافة هذا العميل للنظام بنجاح.");
            }

            return Result.Failure("فشلت عملية إضافة هذا العميل للنظام!");
        }

        //used
        public static Result Update(
            IDbConnection con,
            IDbTransaction trans,
            CustomerModel customer)
        {
            string Query = @"UPDATE Customers
                SET 
                    Active = @Active, Notes = @Notes
                WHERE CustomerID = @CustomerID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@CustomerID",
                    DbType = DbType.Int64,
                    Value = customer.CustomerID,
                },
                new DbParameterInfo
                {
                    Name = "@Active",
                    DbType = DbType.Boolean,
                    Value = customer.Active,
                },
                new DbParameterInfo
                {
                    Name = "@Notes",
                    DbType = DbType.String,
                    Value = customer.Notes,
                }
            };

            Result<int> result = DbManager.Current?.ExecuteNonQuery(
                con,
                trans,
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
                return Result.Success("تمت عملية تحديث بيانات هذا العميل بنجاح.");

            return Result.Failure("فشلت عملية تحديث بيانات هذا العميل!");
        }

        //used
        public static Result Activate(int id)
        {
            string Query = @"UPDATE Customers
                SET 
                    Active = CASE Active
                    WHEN 0 THEN 1
                    ELSE 1
                END
                WHERE CustomerID = @CustomerID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@CustomerID",
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
                    LogManager.LogInfo($"تمت عملية تفعيل هذا العميل {id} بنجاح.");

                    return Result.Success("تمت عملية تفعيل هذا العميل بنجاح.");
                }

                return Result.Failure("لم يتم تفعيل أي عميل!");
            }

            return Result.Failure("فشلت عملية تفعيل هذا العميل!");
        }

        //used
        public static Result Deactivate(int id)
        {
            string Query = @"UPDATE Customers
                SET 
                    Active = CASE Active
                    WHEN 1 THEN 0
                    ELSE 0
                END
                WHERE CustomerID = @CustomerID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@CustomerID",
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
                    LogManager.LogInfo($"تمت عملية تعطيل هذا العميل {id} بنجاح.");

                    return Result.Success("تمت عملية تعطيل هذا العميل بنجاح.");
                }

                return Result.Failure("لم يتم تعطيل أي عميل!");
            }

            return Result.Failure("فشلت عملية تعطيل هذا العميل!");
        }

        //used
        public static Result<bool> IsExist(int id)
        {
            string Query = @"SELECT EXISTS
                (
                    SELECT 1 FROM Customers WHERE CustomerID = @CustomerID
                ) AS IsExist;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@CustomerID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.Scalar<bool>(
                CommandType.Text,
                Query,
                Parameters);
        }

        //public static Result<bool> IsActive(int id)
        //{
        //    string Query = @"SELECT Active FROM Customers 
        //        WHERE CustomerID = @CustomerID;";

        //    DbParameterInfo[] Parameters = new DbParameterInfo[]
        //    {
        //        new DbParameterInfo
        //        {
        //            Name = "@CustomerID",
        //            DbType = DbType.Int64,
        //            Value = id,
        //        },
        //    };

        //    return DataQueryService.Scalar<bool>(
        //        CommandType.Text,
        //        Query,
        //        Parameters);
        //}

        //used
        public static Result<int> GetCount(
            int filterMethodIndex,
            string filterValue)
        {
            string Query = string.Empty;

            switch (filterMethodIndex)
            {
                case (int)FilterMethodsPeople.Name:
                    Query = @"SELECT COUNT(CustomerID) FROM view_CustomersDetails
                        WHERE Name LIKE @FilterValue || '%';";
                    break;

                case (int)FilterMethodsPeople.Phone:
                    Query = @"SELECT COUNT(CustomerID) FROM view_CustomersDetails
                        WHERE Phone LIKE @FilterValue || '%';";
                    break;

                case (int)FilterMethodsPeople.Address:
                    Query = @"SELECT COUNT(CustomerID) FROM view_CustomersDetails
                        WHERE Address LIKE @FilterValue || '%';";
                    break;

                default:
                    Query = @"SELECT COUNT(CustomerID) FROM view_CustomersDetails;";
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
        public static Result<DataTable> GetCustomers(
            int offset,
            int pageSize,
            int filterMethodIndex,
            string filterValue)
        {
            string Query = string.Empty;

            switch (filterMethodIndex)
            {
                case (int)FilterMethodsPeople.Name:
                    Query = @"SELECT CustomerID, Name, Phone, Address,
                        CreatedAt, Active FROM view_CustomersDetails
                        WHERE Name LIKE @FilterValue || '%'
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsPeople.Phone:
                    Query = @"SELECT CustomerID, Name, Phone, Address,
                        CreatedAt, Active FROM view_CustomersDetails
                        WHERE Phone LIKE @FilterValue || '%'
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                case (int)FilterMethodsPeople.Address:
                    Query = @"SELECT CustomerID, Name, Phone, Address,
                        CreatedAt, Active FROM view_CustomersDetails
                        WHERE Address LIKE @FilterValue || '%'
                        LIMIT @PageSize
                        OFFSET @Offset;";
                    break;

                default:
                    Query = @"SELECT CustomerID, Name, Phone, Address,
                        CreatedAt, Active FROM view_CustomersDetails
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

        //used
        public static Result<int> GetCount()
        {
            string Query = @"SELECT COUNT(CustomerID) FROM Customers
                WHERE Active = 1;";

            return DataQueryService.Scalar<int>(CommandType.Text, Query);
        }

        //used
        public static Result<DataTable> GetForSelection()
        {
            string Query = @"SELECT CustomerID, Name FROM view_CustomersDetails
                WHERE view_CustomersDetails.Active = 1
                ORDER BY CustomerID ASC;";

            return DbManager.Current?.GetDataTable(CommandType.Text, Query);
        }
    }
}

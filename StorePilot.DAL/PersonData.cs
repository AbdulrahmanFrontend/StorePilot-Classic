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
    public static class PersonData
    {
        public static Result AddNew(
            IDbConnection con,
            IDbTransaction trans,
            PersonModel newPerson)
        {
            string Query = @"INSERT INTO People (Name, Phone, Address)
                VALUES (@Name, @Phone, @Address);

                SELECT LAST_INSERT_ROWID();";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@Name",
                    DbType = DbType.String,
                    Value = newPerson.Name
                },
                new DbParameterInfo
                {
                    Name = "@Phone",
                    DbType = DbType.String,
                    Value = newPerson.Phone,
                },
                new DbParameterInfo
                {
                    Name = "@Address",
                    DbType = DbType.String,
                    Value = newPerson.Address,
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
                newPerson.PersonID = result.Data;

                return Result.Success("تمت عملية إضافة هذا الشخص للنظام بنجاح.");
            }

            return Result.Failure("فشلت عملية إضافة هذا الشخص للنظام!");
        }

        public static Result Update(
            IDbConnection con,
            IDbTransaction trans,
            PersonModel person)
        {
            string Query = @"UPDATE People
                SET 
                    Name = @Name, Phone = @Phone,
                    Address = @Address
                WHERE PersonID = @PersonID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@PersonID",
                    DbType = DbType.Int64,
                    Value = person.PersonID,
                },
                new DbParameterInfo
                {
                    Name = "@Name",
                    DbType = DbType.String,
                    Value = person.Name
                },
                new DbParameterInfo
                {
                    Name = "@Phone",
                    DbType = DbType.String,
                    Value = person.Phone,
                },
                new DbParameterInfo
                {
                    Name = "@Address",
                    DbType = DbType.String,
                    Value = person.Address,
                },
            };

            Result<int> result = DbManager.Current?.ExecuteNonQuery(
                con,
                trans,
                CommandType.Text,
                Query,
                Parameters);

            if (result.IsSuccess)
                return Result.Success("تمت عملية تحديث بيانات هذا الشخص بنجاح.");

            return Result.Failure("فشلت عملية تحديث بيانات هذا الشخص!");
        }

        public static Result<bool> IsNameExist(string name, int id)
        {
            string Query = @"SELECT EXISTS
                (
                    SELECT 1 FROM People 
                    WHERE Name = @Name AND PersonID != @PersonID
                ) 
                AS IsFound;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@Name",
                    DbType = DbType.String,
                    Value = name,
                },
                new DbParameterInfo
                {
                    Name = "@PersonID",
                    DbType = DbType.Int64,
                    Value = id,
                }
            };

            return DataQueryService.Scalar<bool>(
                CommandType.Text,
                Query,
                Parameters);
        }

        public static Result<bool> IsPhoneExist(string phone, int id)
        {
            string Query = @"SELECT EXISTS
                (
                    SELECT 1 FROM People 
                    WHERE Phone = @Phone AND PersonID != @PersonID
                ) 
                AS IsFound;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@Phone",
                    DbType = DbType.String,
                    Value = phone,
                },
                new DbParameterInfo
                {
                    Name = "@PersonID",
                    DbType = DbType.Int64,
                    Value = id,
                }
            };

            return DataQueryService.Scalar<bool>(
                CommandType.Text,
                Query,
                Parameters);
        }
    }
}

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
    public static class PaymentMethodData
    {
        public static Result<PaymentMethodModel> GetByID(int id)
        {
            string Query = @"SELECT * FROM PaymentMethods
                WHERE MethodID = @MethodID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@MethodID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.FirstOrDefault<PaymentMethodModel>(
                CommandType.Text,
                Query,
                Parameters);
        }

        public static Result<DataTable> GetAll()
        {
            string Query = @"SELECT * FROM PaymentMethods;";

            return DbManager.Current?.GetDataTable(CommandType.Text, Query);
        }

        public static Result<bool> IsFound(int id)
        {
            string Query = @"SELECT EXISTS
            (
                SELECT 1 FROM PaymentMethods WHERE MethodID = @MethodID
            ) AS IsFound;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@MethodID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.Scalar<bool>(CommandType.Text, Query, Parameters);
        }
    }
}

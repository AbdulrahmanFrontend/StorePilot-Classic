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
        //used
        public static Result<PaymentMethodModel> Find(int id)
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

        //used
        public static Result<DataTable> GetAll()
        {
            string Query = @"SELECT * FROM PaymentMethods;";

            return DbManager.Current?.GetDataTable(CommandType.Text, Query);
        }

        //used
        public static Result<bool> IsExist(int id)
        {
            string Query = @"SELECT EXISTS
            (
                SELECT 1 FROM PaymentMethods WHERE MethodID = @MethodID
            ) AS IsExist;";

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

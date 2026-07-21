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
    public static class UnitData
    {
        public static Result<UnitModel> GetByID(int id)
        {
            string Query = @"SELECT * FROM Units WHERE UnitID = @UnitID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@UnitID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.FirstOrDefault<UnitModel>(
                CommandType.Text,
                Query,
                Parameters);
        }

        public static Result<DataTable> GetAll()
        {
            string Query = @"SELECT * FROM Units;";

            return DbManager.Current?.GetDataTable(CommandType.Text, Query);
        }

        public static Result<bool> IsFound(int id)
        {
            string Query = @"SELECT EXISTS
            (
                SELECT 1 FROM Units WHERE UnitID = @UnitID
            ) AS IsFound;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@UnitID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.Scalar<bool>(CommandType.Text, Query, Parameters);
        }
    }
}

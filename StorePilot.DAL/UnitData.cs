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
        //used
        public static Result<UnitModel> Find(int id)
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

        //used
        public static Result<DataTable> GetAll()
        {
            string Query = @"SELECT * FROM Units;";

            return DbManager.Current?.GetDataTable(CommandType.Text, Query);
        }

        //used
        public static Result<bool> IsExist(int id)
        {
            string Query = @"SELECT EXISTS
            (
                SELECT 1 FROM Units WHERE UnitID = @UnitID
            ) AS IsExist;";

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

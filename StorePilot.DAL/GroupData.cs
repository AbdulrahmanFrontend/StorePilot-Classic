using DevToolkit.Core.Results;
using DevToolkit.Data.Core;
using StorePilot.Core.Models;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevToolkit.Data;

namespace StorePilot.DAL
{
    public static class GroupData
    {
        public static Result<GroupModel> Find(int id)
        {
            string Query = @"SELECT * FROM Groups WHERE GroupID = @GroupID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@GroupID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.FirstOrDefault<GroupModel>(
                CommandType.Text, 
                Query, 
                Parameters);
        }

        public static Result<DataTable> GetAll()
        {
            string Query = @"SELECT * FROM Groups;";

            return DbManager.Current?.GetDataTable(CommandType.Text, Query);
        }

        public static Result<bool> IsExist(int id)
        {
            string Query = @"SELECT EXISTS
            (
                SELECT 1 FROM Groups WHERE GroupID = @GroupID
            ) AS IsFound;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@GroupID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.Scalar<bool>(CommandType.Text, Query, Parameters);
        }
    }
}

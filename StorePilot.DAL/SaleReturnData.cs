using DevToolkit.Core.Results;
using DevToolkit.Data;
using DevToolkit.Data.Core;
using StorePilot.Core.Models;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.DAL
{
    public static class SaleReturnData
    {
        public static Result<SaleReturnModel> GetByID(int id)
        {
            string Query = @"SELECT * FROM SalesReturns WHERE ReturnID = @ReturnID;";

            DbParameterInfo[] Parameters = new DbParameterInfo[]
            {
                new DbParameterInfo
                {
                    Name = "@ReturnID",
                    DbType = DbType.Int64,
                    Value = id,
                },
            };

            return DataQueryService.FirstOrDefault<SaleReturnModel>(CommandType.Text,
                Query, 
                Parameters);
        }
    }
}

using DevToolkit.Core.Results;
using StorePilot.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.BLL
{
    public class SaleReturnItemService
    {
        public static Result<DataTable> GetSalesReturnItems(int returnId)
        {
            Result<DataTable> result = SaleReturnItemData.GetSalesReturnItems(returnId);

            if (result.IsSuccess)
                return result;

            return Result<DataTable>.Failure("فشلت عملية الوصول لعناصر فاتورة المرتجع!");
        }
    }
}

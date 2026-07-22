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
    public class InvoiceItemService
    {
        public static Result<DataTable> GetInvoiceItems(int invoiceId)
        {
            Result<DataTable> result = InvoiceItemData.GetInvoiceItems(invoiceId);

            if (result.IsSuccess)
            {
                if (result.Data != null && result.Data.Rows.Count != 0)
                    return result;

                return Result<DataTable>.Failure(
                    "هذه الفاتورة لا تحتوي على أية عناصر!");
            }

            return Result<DataTable>.Failure(
                "فشلت عملية الحصول على عناصر الفاتورة!");
        }
    }
}

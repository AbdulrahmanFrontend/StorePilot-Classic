using DevToolkit.Core;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using StorePilot.Core.Enums;
using StorePilot.Core.Models;
using StorePilot.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.BLL
{
    public abstract class InvoiceService : BaseBusiness
    {
        public static Result<bool> HasPayments(int invoiceId)
        {
            Result<bool> result = InvoiceData.HasPayments(invoiceId);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return result;

                return Result<bool>.Failure("هذه الفاتورة ليس لها سجل دفع!");
            }

            return Result<bool>.Failure(
                "فشلت عملية التحقق من وجود سجل دفع لهذه الفاتورة!");
        }
    }
}

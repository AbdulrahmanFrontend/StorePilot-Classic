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
    public static class InvoiceService
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

        //public static Result<string> GetInvoiceStatus(int invoiceId)
        //{
        //    Result<string> result = InvoiceData.GetInvoiceStatus(invoiceId);

        //    if (result.IsSuccess)
        //        return result;

        //    return Result<string>.Failure("فشلت عملية الوصول لحالة الفاتورة!");
        //}

        //public static Result<bool> IsDeferred(int invoiceId)
        //{
        //    Result<string> result = GetInvoiceStatus(invoiceId);

        //    if (result.IsSuccess)
        //    {
        //        if (result.Data == InvoiceStatus.Deferred.ToArabic())
        //            return Result<bool>.Success(true);

        //        return Result<bool>.Failure("هذه الفاتورة ليست آجل!");
        //    }

        //    return Result<bool>.Failure("فشلت عملية الوصول لحالة الفاتورة!");
        //}
    }
}

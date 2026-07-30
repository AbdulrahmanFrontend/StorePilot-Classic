using DevToolkit.Core.Results;
using StorePilot.Core.Models;
using StorePilot.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.BLL
{
    public class PaymentMethodService
    {
        public PaymentMethodModel Model { get; private set; }

        private int _ID = 0;

        public PaymentMethodService()
        {
            this.Model = new PaymentMethodModel();
            this._ID = this.Model.MethodID;
        }

        public PaymentMethodService(PaymentMethodModel model)
        {
            this.Model = model;
            this._ID = this.Model.MethodID;
        }

        public static Result<PaymentMethodService> Find(int id)
        {
            Result<PaymentMethodModel> result = PaymentMethodData.Find(id);

            if (result.IsSuccess)
            {
                if (result.Data == null)
                    return Result<PaymentMethodService>.Failure(
                        "طريقة الدفع هذه غير مسجلة في النظام!");

                return Result<PaymentMethodService>.Success(
                    new PaymentMethodService(result.Data)
                    );
            }

            return Result<PaymentMethodService>.Failure(
                "فشلت عملية الوصول لبيانات طريقة الدفع هذه!");
        }

        public static Result<DataTable> GetAll()
        {
            Result<DataTable> result = PaymentMethodData.GetAll();

            if (result.IsSuccess)
                return result;

            return Result<DataTable>.Failure("فشلت عملية الوصول لجميع طرق الدفع!");
        }

        public static Result IsExist(int id)
        {
            Result<bool> result = PaymentMethodData.IsExist(id);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return Result.Success();

                return Result.Failure("طريقة الدفع هذه غير مسجلة في النظام!");
            }

            return Result.Failure(
                "فشلت عملية التحقق من وجود طريقة الدفع هذه في النظام!");
        }
    }
}

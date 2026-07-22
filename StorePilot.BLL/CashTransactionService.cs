using DevToolkit.Core;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using DevToolkit.Core.Validation;
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
    public class CashTransactionService : BaseBusiness
    {
        public CashTransactionModel Model { get; private set; }

        public CashTransactionService()
        {
            this.Model = new CashTransactionModel();
            this.Mode = Mode.AddNew;
        }

        public CashTransactionService(CashTransactionModel model)
        {
            this.Model = model;
            this.Mode = Mode.Update;
        }

        public static Result<CashTransactionService> GetByID(int id)
        {
            Result<CashTransactionModel> result = CashTransactionData.GetByID(id);

            if (result.IsSuccess)
            {
                if (result.Data == null)
                    return Result<CashTransactionService>.Failure(
                        "هذه الحركة غير مسجلة في النظام!");

                return Result<CashTransactionService>.Success(
                        new CashTransactionService(result.Data)
                        );
            }

            return Result<CashTransactionService>.Failure(
                "فشلت عملية الوصول لبيانات هذه الحركة!");
        }

        protected override Result _Update()
        {
            Result result = _ValidateBusiness(this.Model.TransactionID);

            if (!result.IsSuccess)
                return result;

            return CashTransactionData.Update(this.Model);
        }

        protected override Result _AddNew() => CashTransactionData.AddNew(this.Model);

        public Result ValidateAmount()
            => _ValidateProperty(nameof(this.Model.Amount), this.Model);

        public Result ValidateDescription()
            => _ValidateProperty(nameof(this.Model.Description), this.Model);

        public Result ValidateNotes()
            => _ValidateProperty(nameof(this.Model.Notes), this.Model);

        private static Result _ValidateBusiness(int id)
        {
            Result<bool> RevenueResult = CashTransactionData.IsRevenue(id);

            if (RevenueResult.IsSuccess)
            {
                if (RevenueResult.Data)
                    return Result.Failure(
                        "ممنوع حذف او تعديل حركة إيرادات من شاشة الصندوق!");
            }
            else
                return Result.Failure("فشلت عملية التحقق من نوع الحركة!");

            //var result =
            //    PurchaseInvoiceData.IsPurchaseTransaction(id);

            //if (result.IsSuccess)
            //{
            //    if (result.Data)
            //        return Result.Failure("لا يسمح بتعديل أو حذف حركة مصروفات شراء!");
            //}
            //else
            //    return Result.Failure("فشلت عملية التحقق من كون الحركة مصروفات شراء!");

            return Result.Success();
        }

        protected override ValidationResult _Validate()
            => ObjectValidator.ValidateObject<CashTransactionModel>(Model);

        public static Result Cancelled(int id)
        {
            Result result = _ValidateBusiness(id);

            if (!result.IsSuccess)
                return result;

            return CashTransactionData.Cancell(id);
        }

        public static Result IsFound(int id)
        {
            Result<bool> result = CashTransactionData.IsFound(id);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return Result.Success();

                return Result.Failure("هذه الحركة غير مسجلة في النظام!");
            }

            return Result.Failure(
                "فشلت عملية التحقق من وجود هذه الحركة في النظام!");
        }

        //public static Result IsPurchaseTransaction(int id)
        //{
        //    var result =
        //        PurchaseInvoiceData.IsPurchaseTransaction(id);

        //    if (result.IsSuccess)
        //    {
        //        if (result.Data)
        //            return Result.Success();

        //        return Result.Failure("هذه الحركة ليست مصروفات فاتورة شراء!");
        //    }

        //    return Result.Failure("فشلت عملية التحقق من كون هذه الحركة مصروفات شراء!");
        //}

        public static Result<int> GetCount(
            int filterMethodIndex,
            string filterValue)
        {
            Result<int> result = CashTransactionData.GetCount(
                filterMethodIndex,
                filterValue);

            if (result.IsSuccess)
                return result;

            return Result<int>.Failure("فشلت عملية الحصول على عدد حركات الصندوق!");
        }

        public static Result<DataTable> GetCashTransactions(
            int currentPage,
            int pageSize,
            int filterMethodIndex,
            string filterValue)
        {
            int offset = (currentPage - 1) * pageSize;

            Result<DataTable> result = CashTransactionData.GetCashTransactions(
                offset,
                pageSize,
                filterMethodIndex,
                filterValue);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                    return result;

                return Result<DataTable>.Success(default);
            }

            return Result<DataTable>.Failure(
                "فشلت عملية الحصول على جميع حركات الصيدوق!");
        }

        public static Result<decimal> GetCurrentBalance()
        {
            Result<decimal> result = CashTransactionData.GetCurrentBalance();

            if (result.IsSuccess)
                return result;

            return Result<decimal>.Failure("فشلت عملية الوصول لرصيد الصندوق!");
        }
    }
}

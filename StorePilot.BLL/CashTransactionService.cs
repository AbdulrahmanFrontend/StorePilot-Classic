using DevToolkit.Core;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using DevToolkit.Core.Validation;
using StorePilot.Core.Models;
using StorePilot.DAL;
using System.Data;

namespace StorePilot.BLL
{
    public class CashTransactionService : BaseBusiness
    {
        public CashTransactionModel Model { get; private set; }

        private int _ID = 0;

        public CashTransactionService()
        {
            this.Model = new CashTransactionModel();
            this._ID = this.Model.TransactionID;
            this.Mode = Mode.AddNew;
        }

        public CashTransactionService(CashTransactionModel model)
        {
            this.Model = model;
            this._ID = this.Model.TransactionID;
            this.Mode = Mode.Update;
        }

        public static Result<CashTransactionService> Find(int id)
        {
            Result<CashTransactionModel> result = CashTransactionData.Find(id);

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

            this.Model.TransactionID = this._ID;

            return CashTransactionData.Update(this.Model);
        }

        protected override Result _AddNew()
        {
            this.Model.TransactionID = this._ID;

            return CashTransactionData.AddNew(this.Model); 
        }

        public Result ValidatePaidAmount()
            => _ValidateProperty(nameof(this.Model.PaidAmount), this.Model);

        public Result ValidateDescription()
            => _ValidateProperty(nameof(this.Model.Description), this.Model);

        public Result ValidateNotes()
            => _ValidateProperty(nameof(this.Model.Notes), this.Model);

        private static Result _ValidateBusiness(int id)
        {
            Result<CashTransactionModel> GetTransResult = CashTransactionData.Find(id);

            if (GetTransResult.IsSuccess)
            {
                if (GetTransResult.Data == null)
                    return Result.Failure("هذه الحركة غير مسجلة في النظام!");
            }
            else
                return Result.Failure("فشلت عملية الوصول لبيانات حركة الصندوق هذه!");

            return IsDependentTransaction(id);
        }

        protected override ValidationResult _Validate()
            => ObjectValidator.ValidateObject<CashTransactionModel>(Model);

        public static Result IsExist(int id)
        {
            Result<bool> result = CashTransactionData.IsExist(id);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return Result.Success();

                return Result.Failure("هذه الحركة غير مسجلة في النظام!");
            }

            return Result.Failure(
                "فشلت عملية التحقق من وجود هذه الحركة في النظام!");
        }

        public static Result<int> GetCount(
            int filterMethodIndex,
            string filterValue,
            bool cancelled)
        {
            Result<int> result = CashTransactionData.GetCount(
                filterMethodIndex,
                filterValue,
                cancelled);

            if (result.IsSuccess)
                return result;

            return Result<int>.Failure("فشلت عملية الحصول على عدد حركات الصندوق!");
        }

        public static Result<DataTable> GetCashTransactions(
            int currentPage,
            int pageSize,
            int filterMethodIndex,
            string filterValue,
            bool cancelled)
        {
            int offset = (currentPage - 1) * pageSize;

            Result<DataTable> result = CashTransactionData.GetCashTransactions(
                offset,
                pageSize,
                filterMethodIndex,
                filterValue,
                cancelled);

            if (result.IsSuccess)
                return result;

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

        public static Result IsDependentTransaction(int id)
        {
            Result<bool> IsValidTransResult =
                PurchaseInvoiceData.IsPurchasesTransaction(id);

            if (IsValidTransResult.IsSuccess && IsValidTransResult.Data)
                return Result.Failure("لا يسمح بتعديل أو حذف حركة مصروفات شراء!");
            else if (!IsValidTransResult.IsSuccess)
                return Result.Failure("فشلت عملية التحقق من كون الحركة مصروفات شراء!");

            IsValidTransResult = SaleReturnData.IsReturnsTransaction(id);

            if (IsValidTransResult.IsSuccess && IsValidTransResult.Data)
                return Result.Failure("لا يسمح بتعديل أو حذف حركة مصروفات مرتجعات!");
            else if (!IsValidTransResult.IsSuccess)
                return Result.Failure("فشلت عملية التحقق من كون الحركة مصروفات مرتجعات!");

            IsValidTransResult = SaleInvoiceData.IsSalesTransaction(id);

            if (IsValidTransResult.IsSuccess && IsValidTransResult.Data)
                return Result.Failure("لا يسمح بتعديل أو حذف حركة إيرادات مبيعات!");
            else if (!IsValidTransResult.IsSuccess)
                return Result.Failure("فشلت عملية التحقق من كون الحركة إيرادات مبيعات!");

            IsValidTransResult = PaymentData.IsPaymentsTransaction(id);

            if (IsValidTransResult.IsSuccess && IsValidTransResult.Data)
                return Result.Failure("لا يسمح بتعديل أو حذف حركة تحصيل أو سداد ديون!");
            else if (!IsValidTransResult.IsSuccess)
                return Result.Failure(
                    "فشلت عملية التحقق من كون الحركة تحصيل أو سداد ديون!");

            return Result.Success();
        }
    }
}

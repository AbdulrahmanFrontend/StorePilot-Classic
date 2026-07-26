using DevToolkit.Core;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using DevToolkit.Data.Core;
using DevToolkit.Logging.Managers;
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
    public class PaymentService : BaseBusiness
    {
        public PaymentModel Model { get; private set; }

        public PaymentService()
        {
            this.Model = new PaymentModel();
            this.Mode = Mode.AddNew;
        }

        private PaymentService(PaymentModel model)
        {
            this.Model = model;
            this.Mode = Mode.Update;
        }

        public static Result<PaymentService> GetByID(int id)
        {
            Result<PaymentModel> result = PaymentData.GetByID(id);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                    return Result<PaymentService>.Success(
                        new PaymentService(result.Data)
                        );

                return Result<PaymentService>.Failure(
                    "عملية الدفع هذه غير مسجلة في هذا النظام!");
            }

            return Result<PaymentService>.Failure(
                "فشلت عملية الوصول لبيانات عملية الدفع هذه!");
        }

        protected override Result _AddNew()
        {
            CashTransactionModel TransModel = new CashTransactionModel();

            TransModel.TransactionDate = Model.PaymentDate;
            TransModel.Amount = Model.PaidAmount;
            
            TransModel.Description = $"تحصيل دين.";
            Result result = DbManager.Current?.ExecuteTransaction(
                (con, trans) =>
                {
                    Result SubResult = CashTransactionData.AddNew(
                        con,
                        trans,
                        TransModel);

                    _ThrowException(SubResult);

                    Model.TransactionID = TransModel.TransactionID;

                    SubResult = PaymentData.AddNew(
                        con,
                        trans,
                        Model);

                    _ThrowException(SubResult);

                    SubResult = InvoiceData.UpdatePaidAmount(
                        con,
                        trans,
                        Model.InvoiceID);

                    _ThrowException(SubResult);

                    SubResult = InvoiceData.UpdateStatus(
                        con,
                        trans,
                        Model.InvoiceID);

                    _ThrowException(SubResult);
                });

            if (result.IsSuccess)
            {
                LogManager.LogInfo($"تمت عملية إضافة عملية الدفع " +
                    $"{Model.PaymentID} هذه بنجاح.");

                return Result.Success(
                    "تمت عملية حفظ بيانات عملية الدفع هذه بنجاح.");
            }

            return Result.Failure("فشلت عملية حفظ بيانات عملية الدفع هذه!");
        }

        protected override Result _Update()
        {
            return Result.Failure(
                "غير مسموح بتعديل بيانات " +
                "عملية الدفع هذه يرجى حذفها وإنشاء عملية جديدة!");
        }

        public override Result Valid()
        {
            Result result = ValidateInvoiceStatus();

            if (!result.IsSuccess)
                return result;

            result = ValidateAmount();

            if (!result.IsSuccess)
                return result;

            result = ValidateDate();

            if (!result.IsSuccess)
                return result;

            result = ValidateNotes();

            if (!result.IsSuccess)
                return result;

            return result;
        }

        public Result ValidateInvoiceStatus()
            => SaleInvoiceService.IsDeferred(this.Model.InvoiceID);

        public Result ValidateNotes() =>
            _ValidateProperty(nameof(this.Model.Notes), this.Model);

        public Result ValidateAmount()
        {
            var result = InvoiceData.GetRemainingAmount(
                this.Model.InvoiceID);

            if (result.IsSuccess)
            {
                if (this.Model.PaidAmount > result.Data)
                    return Result.Failure(
                        "المبلغ المدفوع أكبر من المبلغ المتبقي!");
            }
            else
                return Result.Failure(result.Message);

            return Result.Success();
        }

        public Result ValidateDate()
        {
            Result<DateTime> result = InvoiceData.GetInvoiceDate(
                this.Model.InvoiceID);

            if (result.IsSuccess)
            {
                if (this.Model.PaymentDate < result.Data)
                    return Result.Failure(
                        $"يجب أن يكون تاريخ الدفع بعد أو مساويا لتاريخ البيع " +
                        $"{result.Data.ToString("dd/MM/yyyy hh:mm tt")}!");
            }
            else
                return Result.Failure("فشلت عملية الحصول على تاريخ البيع!");

            return Result.Success();
        }

        public static Result Delete(int id)
        {
            Result<decimal> AmountResult = PaymentData.GetAmount(id);

            if (!AmountResult.IsSuccess)
                return Result.Failure("فشلت عملية الوصول للمبلغ المدفوع!");

            Result<int> InvoiceIDResult = PaymentData.GetInvoiceID(id);

            if (!InvoiceIDResult.IsSuccess)
                return Result.Failure("فشلت عملية الوصول لفاتورة عملية الدفع!");

            Result<int> TransIDResult = PaymentData.GetTransactionID(id);

            if (!TransIDResult.IsSuccess)
                return Result.Failure("فشلت عملية الوصول لحركة عملية الدفع هذه!");

            Result DeleteResult = DbManager.Current?.ExecuteTransaction(
                (con, trans) =>
                {
                    var result = SaleInvoiceData.ReturnPaymentAmount(
                        con,
                        trans,
                        InvoiceIDResult.Data,
                        AmountResult.Data);

                    _ThrowException(result);

                    result = SaleInvoiceData.UpdateStatus(
                        con,
                        trans,
                        InvoiceIDResult.Data);

                    _ThrowException(result);

                    result = PaymentData.Cancell(con, trans, id);

                    _ThrowException(result);

                    result = CashTransactionData.Cancell(
                        con,
                        trans,
                        TransIDResult.Data);

                    _ThrowException(result);
                });

            if (DeleteResult.IsSuccess)
            {
                LogManager.LogInfo($"تمت عملية حذف عملية الدفع {id} هذه بنجاح.");
                return Result.Success("تمت عملية حذف عملية الدفع هذه بنجاح.");
            }

            return Result.Failure("فشلت عملية حذف عملية الدفع هذه!");
        }

        public static Result IsFound(int id)
        {
            Result<bool> result = PaymentData.IsFound(id);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return Result.Success();

                return Result.Failure("هذه الدفعة غير مسجلة في هذا النظام!");
            }

            return Result.Failure(
                "فشلت عملية التحقق من وجود هذه الدفعة في النظام.");
        }

        public static Result<int> GetCountForInvoice(
            int invoiceId,
            int filterMethodIndex,
            string filterValue)
        {
            Result<int> result = PaymentData.GetPaymentsInvoiceCount(
                invoiceId,
                filterMethodIndex,
                filterValue);

            if (result.IsSuccess)
                return result;

            return Result<int>.Failure(
                "فشلت عملية الحصول على عدد مدفوعات الفاتورة!");
        }

        public static Result<DataTable> GetForInvoice(
            int invoiceId,
            int currentPage,
            int pageSize,
            int filterMethodIndex,
            string filterValue)
        {
            int offset = (currentPage - 1) * pageSize;

            Result<DataTable> result = PaymentData.GetPaymentsInvoice(
                invoiceId,
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
                "فشلت عملية الحصول على جميع مدفوعات الفاتورة!");
        }

        public static Result<DataTable> GetPayments(int invoiceId)
        {
            Result<DataTable> result = PaymentData.GetInvoicePayments(invoiceId);

            if (result.IsSuccess)
                return result;

            return Result<DataTable>.Failure(
                "فشلت عملية الوصول لعملية مدفوعات الفاتورة!");
        }
    }
}

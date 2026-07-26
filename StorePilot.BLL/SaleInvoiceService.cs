using DevToolkit.Core;
using DevToolkit.Core.Common;
using DevToolkit.Core.Guards;
using DevToolkit.Core.Results;
using DevToolkit.Data.Core;
using DevToolkit.Logging.Managers;
using StorePilot.Core.Enums;
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
    public class SaleInvoiceService : BaseBusiness
    {
        public SaleInvoiceModel Model { get; private set; }

        protected List<InvoiceItemModel> _Items { get; set; }

        public SaleInvoiceService()
        {
            this.Model = new SaleInvoiceModel();
            _Items = new List<InvoiceItemModel>();
            this.Mode = Mode.AddNew;
        }

        public SaleInvoiceService(SaleInvoiceModel model)
        {
            this.Model = model;
            this.Mode = Mode.Update;
        }
        
        public void SetItems(IEnumerable<InvoiceItemModel> items)
        {
            this._Items.Clear();

            this._Items.AddRange(items);
        }

        public static Result<SaleInvoiceService> GetByID(int id)
        {
            Result<SaleInvoiceModel> result = SaleInvoiceData.GetByID(id);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                    return Result<SaleInvoiceService>.Success(
                        new SaleInvoiceService(result.Data)
                        );

                return Result<SaleInvoiceService>.Failure(
                    "هذه الفاتورة غير مسجلة في هذا النظام!");
            }

            return Result<SaleInvoiceService>.Failure(
                "فشلت عملية الوصول لبيانات هذه الفاتورة!");
        }

        protected override Result _AddNew()
        {
            this.Model.TotalAmount = _Items.Sum(i => i.TotalPrice);

            switch (Model.InvoiceStatus.ToInvoiceStatus())
            {
                case InvoiceStatus.Paid:
                    Model.PaidAmount = this.Model.TotalAmount;
                    break;

                case InvoiceStatus.Deferred:
                    Model.PaidAmount = 0;
                    break;
            }

            Result TransactionResult = DbManager.Current?.ExecuteTransaction(
                (con, trans) =>
                {
                    CashTransactionModel transModel;
                    Result InnerResult;

                    if (Model.InvoiceStatus == InvoiceStatus.Paid.ToArabic())
                    {
                        transModel = new CashTransactionModel
                        {
                            TransactionDate = Model.InvoiceDate,
                            TransactionType = TransactionType.Revenue.ToArabic(),
                            Amount = Model.TotalAmount,
                            Description = $"إيرادات فاتورة بيع",
                            Notes = Model.Notes,
                        };

                        InnerResult = CashTransactionData.AddNew(
                            con,
                            trans,
                            transModel);

                        _ThrowException(InnerResult);

                        this.Model.TransactionID = transModel.TransactionID;
                    }

                    InnerResult = InvoiceData.AddNew(con, trans, Model);

                    _ThrowException(InnerResult);

                    InnerResult = SaleInvoiceData.AddNew(con, trans, Model);

                    _ThrowException(InnerResult);

                    foreach (InvoiceItemModel item in _Items)
                    {
                        item.InvoiceID = Model.InvoiceID;

                        InnerResult = InvoiceItemData.AddNew(con, trans, item);

                        _ThrowException(InnerResult);
                    }

                    InnerResult = ProductData.IncreaseStock(
                        con,
                        trans,
                        this.Model.InvoiceID);

                    _ThrowException(InnerResult);
                });

            if (TransactionResult.IsSuccess)
            {
                LogManager.LogInfo(
                    $"تمت عملية حفظ فاتورة البيع {Model.SaleInvoiceID} بنجاح.");

                return Result.Success("تمت عملية حفظ الفاتورة بنجاح.");
            }

            return Result.Failure("فشلت عملية حفظ الفاتورة!");
        }

        protected override Result _Update()
        {
            CashTransactionModel transModel = new CashTransactionModel();

            if (this.Model.TransactionID.HasValue)
            {
                Result<CashTransactionModel> result =
                    CashTransactionData.GetByID(this.Model.TransactionID.Value);

                if (result.IsSuccess)
                    transModel = result.Data;
                else
                    return Result.Failure("فشلت عملية الوصول لحركة هذه الفاتورة!");
            }

            Result ValidateDateResult = ValidateInvoiceDate();

            if (!ValidateDateResult.IsSuccess)
                return ValidateDateResult;

            Result<bool> IsCancelledResult = IsCancelled(this.Model.SaleInvoiceID);

            if (!IsCancelledResult.IsSuccess)
                return Result.Failure(IsCancelledResult.Message);

            Result TransactionResult = DbManager.Current?.ExecuteTransaction(
                (con, trans) =>
                {
                    Result InnerResult = InvoiceData.Update(con, trans, Model);

                    _ThrowException(InnerResult);

                    if (this.Model.TransactionID.HasValue)
                    {
                        InnerResult = CashTransactionData.Update(
                            con,
                            trans,
                            transModel);

                        _ThrowException(InnerResult);
                    }

                    InnerResult = SaleInvoiceData.Update(con, trans, Model);

                    _ThrowException(InnerResult);
                });

            if (TransactionResult.IsSuccess)
            {
                LogManager.LogInfo($"تمت عملية تحديث بيانات فاتورة البيع " +
                    $"{Model.SaleInvoiceID} بنجاح.");

                return Result.Success("تمت عملية تحديث بيانات الفاتورة بنجاح.");
            }

            return Result.Failure("فشلت عملية حفظ الفاتورة!");
        }

        public override Result Valid()
        {
            Result result = ValidateItems();

            if (!result.IsSuccess)
                return result;

            result = ValidateStatus();

            if (!result.IsSuccess)
                return result;

            return result;
        }

        public Result ValidateItems()
        {
            if (!Guard.HasItems(_Items))
                return Result.Failure("يجب إضافة عناصر للفاتورة أولا!");

            foreach (InvoiceItemModel item in _Items)
            {
                Result<ProductService> result = ProductService.GetByID(item.ProductID);

                if (result.IsSuccess)
                    return Result.Failure("هذا الصنف غير مسجل في النظام!");

                if (item.Quantity <= 0)
                    return Result.Failure(
                        "هنك صنف الكمية المطلوبة منه أصغر من أو تساوي الصفر!");

                if (item.Quantity >= result.Data.Model.Quantity)
                    return Result.Failure(
                        "هنك صنف الكمية المطلوبة منه أكبر من الكمية المتوفرة في المخزن!");

                if (item.UnitPrice <= 0)
                    return Result.Failure(
                        "هناك صنف سعر الوحدة له أصغر من أو يساوي الصفر!");
            }

            return Result.Success();
        }

        public Result ValidateStatus()
        {
            switch (Model.InvoiceStatus.ToInvoiceStatus())
            {
                case InvoiceStatus.Paid:
                    if (Model.CustomerID.HasValue)
                        return Result.Success();

                    return SupplierService.IsFound(Model.CustomerID.Value);

                case InvoiceStatus.Deferred:
                    if (Model.CustomerID.HasValue)
                        return Result.Failure(
                            "يجب أن يكون إدخال العميل لفاتورة الآجل!");

                    return SupplierService.IsFound(Model.CustomerID.Value);

                default:
                    return Result.Failure("حالة البيع غير صالحة!");
            }
        }

        public Result ValidateInvoiceDate()
        {
            Result<bool> result = InvoiceService.HasPayments(this.Model.InvoiceID);

            if (result.IsSuccess)
            {
                if (result.Data)
                {
                    result = PaymentData.IsInvoiceDateLargerThanPaymentsDate(
                        this.Model.InvoiceID,
                        this.Model.InvoiceDate);

                    if (result.IsSuccess)
                    {
                        if (result.Data)
                            return Result.Failure("يجب أن يكون تاريخ الفاتورة الجديد "
                                + "أصغر من كل تواريخ الدفع او مساوي لأقل تاريخ دفع!");

                        return Result.Success();
                    }

                    return Result.Failure(
                        "فشلت عملية المقارنة بين تاريخ الفاتورة الجديد" +
                        " وبين تواريخ سجلات دفع الفاتورة!");
                }

                return Result.Success();
            }

            return Result.Failure("فشلت عملية التحقق من وجود سجلات دفع لهذه الفاتورة!");
        }

        public static Result Cancell(int invoiceId)
        {
            Result<bool> IsCancelledResult = IsCancelled(invoiceId);

            if (IsCancelledResult.IsSuccess)
            {
                if (IsCancelledResult.Data)
                    return Result.Failure("هذه الفاتورة ملغية فعلا!");
            }
            else
                return Result.Failure(IsCancelledResult.Message);

            Result TransResult = DbManager.Current.ExecuteTransaction(
                (con, trans) =>
                {
                    Result result = ProductData.DecreaseStock(con, trans, invoiceId);

                    _ThrowException(result);

                    result = SaleInvoiceData.Cancell(con, trans, invoiceId);

                    _ThrowException(result);

                    result = PaymentData.CancellInvoicePayments(con, trans, invoiceId);

                    _ThrowException(result);

                    result = CashTransactionData.CancellPaymentsTransactions(
                        con,
                        trans,
                        invoiceId);

                    _ThrowException(result);

                    result = CashTransactionData.CancellInvoiceTransaction(
                        con,
                        trans,
                        invoiceId);

                    _ThrowException(result);
                });

            if (TransResult.IsSuccess)
            {
                LogManager.LogInfo($"تمت عملية إلغاء فاتورة البيع {invoiceId} بنجاح.");

                return Result.Success("تمت عملية الإلغاء بنجاح.");
            }

            return Result.Failure("فشلت عملية إلغاء هذه الفاتورة!");
        }

        public static Result IsFound(int id)
        {
            Result<bool> result = SaleInvoiceData.IsFound(id);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return Result.Success();

                return Result.Failure("هذه الفاتورة غير مسجلة في هذا النظام!");
            }

            return Result.Failure(
                "فشلت عملية التحقق من وجود هذه الفاتورة في النظام!");
        }

        public static Result<int> GetCount()
        {
            Result<int> result = SaleInvoiceData.GetCount();

            if (result.IsSuccess)
                return result;

            return Result<int>.Failure("فشلت عملية الحصول على عدد فواتير البيع!");
        }

        public static Result<int> GetCount(
            int filterMethodIndex,
            string filterValue)
        {
            Result<int> result = SaleInvoiceData.GetCount(
                filterMethodIndex,
                filterValue);

            if (result.IsSuccess)
                return result;

            return Result<int>.Failure("فشلت عملية الحصول على عدد فواتير البيع!");
        }

        public static Result<DataTable> GetInvoices(
            int currentPage,
            int pageSize,
            int filterMethodIndex,
            string filterValue)
        {
            int offset = (currentPage - 1) * pageSize;

            Result<DataTable> result = SaleInvoiceData.GetInvoices(
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
                "فشلت عملية الحصول على جميع فواتير البيع!");
        }

        public static Result<bool> IsCancelled(int id)
        {
            Result<bool> result = SaleInvoiceData.IsCancelled(id);

            if (result.IsSuccess)
                return result;

            return Result<bool>.Failure("فشلت عملية التحقق من إلغاء هذه الفاتورة!");
        }
    }
}

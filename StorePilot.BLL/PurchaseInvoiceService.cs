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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.BLL
{
    public class PurchaseInvoiceService : BaseBusiness
    {
        public PurchaseInvoiceModel Model { get; private set; }

        private List<InvoiceItemModel> _Items { get; set; }

        public PurchaseInvoiceService()
        {
            this.Model = new PurchaseInvoiceModel();
            this._Items = new List<InvoiceItemModel>();
            this.Mode = Mode.AddNew;
        }

        public PurchaseInvoiceService(PurchaseInvoiceModel model)
        {
            this.Model = model;
            this.Mode = Mode.Update;
        }

        public static Result<PurchaseInvoiceService> Find(
            int id)
        {
            var result = PurchaseInvoiceData.Find(id);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                    return Result<PurchaseInvoiceService>.Success(
                        new PurchaseInvoiceService(result.Data)
                        );

                return Result<PurchaseInvoiceService>.Failure(
                    "هذه الفاتورة غير مسجلة في النظام!");
            }

            return Result<PurchaseInvoiceService>.Failure(
                "فشلت عملية الوصول لبيانات هذه الفاتورة!");
        }

        public void SetItems(IEnumerable<InvoiceItemModel> items)
        {
            this._Items.Clear();

            this._Items.AddRange(items);
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

            Result TransactionResult = DbManager.Current?.ExecuteTransaction((con, trans) => 
            {
                CashTransactionModel transModel;
                Result InnerResult;

                if (Model.InvoiceStatus == InvoiceStatus.Paid.ToArabic())
                {
                    transModel = new CashTransactionModel
                    {
                        TransactionDate = Model.InvoiceDate,
                        TransactionType = TransactionType.Expense.ToArabic(),
                        PaidAmount = Model.TotalAmount,
                        Description = $"مصروفات فاتورة شراء",
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

                InnerResult = PurchaseInvoiceData.AddNew(con, trans, Model);

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
                    $"تمت عملية حفظ فاتورة الشراء {Model.PurchaseInvoiceID} بنجاح.");

                return Result.Success("تمت عملية حفظ الفاتورة بنجاح.");
            }

            return Result.Failure("فشلت عملية حفظ الفاتورة!");
        }

        protected override Result _Update()
        {
            return Result.Failure("لا يسمح بتعديل أي فاتورة في النظام," +
                " يرجى إلغاء هذه الفاتورة وإنشاء أخرى جديدة!");
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
                Result<ProductModel> result = ProductData.Find(item.ProductID);

                if (!result.IsSuccess || result.Data == null)
                    return Result.Failure("هناك صنف غير مسجل في النظام," +
                        "أو أن عملية الوصول لبيانات الصنف فشلت!");

                if (!result.Data.Active)
                    return Result.Failure(
                        $"الصنف {result.Data.ProductName} غير مفعل في النظام!");

                if (_Items.Count(i => i.ProductID == item.ProductID) > 1)
                    return Result.Failure(
                        $"الصنف {result.Data.ProductName} مكرر في الفاتورة!");

                if (item.Quantity <= 0)
                    return Result.Failure(
                        $"الصنف {result.Data.ProductName} الكمية المطلوبة منه أصغر من " +
                        $"أو تساوي الصفر!");

                if (item.UnitPrice <= 0)
                    return Result.Failure(
                        $"الصنف {result.Data.ProductName} سعر الوحدة له أصغر من " +
                        $"أو يساوي الصفر!");
            }

            return Result.Success();
        }

        public Result ValidateStatus()
        {
            switch (Model.InvoiceStatus.ToInvoiceStatus())
            {
                case InvoiceStatus.Paid:
                    if (!Model.SupplierID.HasValue)
                        return Result.Success();

                    return SupplierService.IsExist(Model.SupplierID.Value);

                case InvoiceStatus.Deferred:
                    if(!Model.SupplierID.HasValue)
                        return Result.Failure(
                            "يجب أن يكون إدخال المورد لفاتورة الآجل!");

                    return SupplierService.IsExist(Model.SupplierID.Value);

                default:
                    return Result.Failure("حالة الشراء غير صالحة!");
            }
        }

        public static Result Cancell(int id)
        {
            var InvoiceResult = PurchaseInvoiceData.Find(id);

            if (!InvoiceResult.IsSuccess || InvoiceResult.Data == null)
                return Result.Failure("هذه الفاتورة غير مسجلة في النظام," +
                    " أو أن عملية الوصول لبيانات الفاتورة فشلت!");

            if (InvoiceResult.Data.Cancelled)
                return Result.Failure("هذه الفاتورة ملغية بالفعل!");

            Result TransResult = DbManager.Current?.ExecuteTransaction(
                (con, trans) =>
                {
                    Result result = ProductData.DecreaseStock(
                        con,
                        trans, 
                        InvoiceResult.Data.InvoiceID);

                    _ThrowException(result);

                    result = PurchaseInvoiceData.Cancell(
                        con, 
                        trans,
                        InvoiceResult.Data.InvoiceID);

                    _ThrowException(result);

                    result = PaymentData.CancellInvoicePayments(
                        con, 
                        trans,
                        InvoiceResult.Data.InvoiceID);

                    _ThrowException(result);

                    result = CashTransactionData.CancellInvoicePaymentsTransactions(
                        con,
                        trans,
                        InvoiceResult.Data.InvoiceID);

                    _ThrowException(result);

                    if (InvoiceResult.Data.TransactionID.HasValue)
                    {
                        result = CashTransactionData.Cancell(
                            con,
                            trans,
                            InvoiceResult.Data.TransactionID.Value);

                        _ThrowException(result);
                    }
                });

            if (TransResult.IsSuccess)
            {
                LogManager.LogInfo($"تمت عملية إلغاء فاتورة الشراء " +
                    $"{id} بنجاح.");

                return Result.Success("تمت عملية الإلغاء بنجاح.");
            }

            return Result.Failure("فشلت عملية إلغاء هذه الفاتورة!");
        }

        public static Result IsExist(int id)
        {
            Result<bool> result = PurchaseInvoiceData.IsExist(id);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return Result.Success();

                return Result.Failure("هذه الفاتورة غير مسجلة في النظام!");
            }

            return Result.Failure(
                "فشلت عملية التحقق من وجود هذه الفاتورة في النظام!");
        }

        public static Result<int> GetCount(
            int filterMethodIndex,
            string filterValue,
            bool cancelled)
        {
            if (!int.TryParse(filterValue?.ToString(), out int Value) &&
                (filterMethodIndex == 0 || filterMethodIndex == 1))
                filterMethodIndex = -1;

            Result<int> result = PurchaseInvoiceData.GetCount(
                filterMethodIndex,
                filterValue,
                cancelled);

            if (result.IsSuccess)
                return result;

            return Result<int>.Failure("فشلت عملية الحصول على عدد فواتير الشراء!");
        }

        public static Result<DataTable> GetInvoices(
            int currentPage,
            int pageSize,
            int filterMethodIndex,
            string filterValue,
            bool cancelled)
        {
            int offset = (currentPage - 1) * pageSize;

            if (!int.TryParse(filterValue?.ToString(), out int Value) &&
                (filterMethodIndex == 0 || filterMethodIndex == 1))
                filterMethodIndex = -1;

            Result<DataTable> result = PurchaseInvoiceData.GetInvoices(
                offset,
                pageSize,
                filterMethodIndex,
                filterValue,
                cancelled);

            if (result.IsSuccess)
                return result;

            return Result<DataTable>.Failure(
                "فشلت عملية الحصول على جميع فواتير الشراء!");
        }
    }
}

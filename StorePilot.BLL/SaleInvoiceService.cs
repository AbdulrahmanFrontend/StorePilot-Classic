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
            this._Items = new List<InvoiceItemModel>();
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

        public static Result<SaleInvoiceService> Find(int id)
        {
            Result<SaleInvoiceModel> result = SaleInvoiceData.Find(id);

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
                            PaidAmount = Model.TotalAmount,
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

                    InnerResult = ProductData.DecreaseStock(
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
            return Result.Failure("لا يسمح بتعديل أي فاتورة في النظام," +
                " يرجى إلغاء هذه الفاتورة ثم إنشاء أخرى جديدة");
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
                    return Result.Failure($"هناك صنف غير مسجل في النظام, " +
                        $"أو عملية الوصول لبيانات الصنف فشلت!");

                if(!result.Data.Active)
                    return Result.Failure(
                        $"الصنف {result.Data.ProductName} غير مفعل في النظام!");

                if (_Items.Count(i => i.ProductID == item.ProductID) > 1)
                    return Result.Failure(
                        $"الصنف {result.Data.ProductName} مكرر في الفاتورة!");

                if (item.Quantity <= 0)
                    return Result.Failure(
                        $"الصنف {result.Data.ProductName} الكمية المطلوبة منه أصغر من " +
                        $"أو تساوي الصفر!");

                if (item.Quantity > result.Data.Quantity)
                    return Result.Failure(
                        $"الصنف {result.Data.ProductName} الكمية المطلوبة منه أكبر من " +
                        $"الكمية المتوفرة في المخزن!");

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
                    if (!Model.CustomerID.HasValue)
                        return Result.Success();

                    return CustomerService.IsExist(Model.CustomerID.Value);

                case InvoiceStatus.Deferred:
                    if (!Model.CustomerID.HasValue)
                        return Result.Failure("يجب إدخال العميل لفاتورة الآجل!");

                    return CustomerService.IsExist(Model.CustomerID.Value);

                default:
                    return Result.Failure("حالة البيع غير صالحة!");
            }
        }

        public static Result Cancell(int id)
        {
            var InvoiceResult = SaleInvoiceData.Find(id);

            if (!InvoiceResult.IsSuccess || InvoiceResult.Data == null)
                return Result.Failure("هذه الفاتورة غير مسجلة في النظام," +
                    " أو أن عملية الوصول لبيانات الفاتورة فشلت!");

            if (InvoiceResult.Data.Cancelled)
                return Result.Failure("هذه الفاتورة ملغية بالفعل!");

            Result TransResult = DbManager.Current?.ExecuteTransaction(
                (con, trans) =>
                {
                    Result result = ProductData.IncreaseStock(
                        con, 
                        trans,
                        InvoiceResult.Data.InvoiceID);

                    _ThrowException(result);

                    result = SaleInvoiceData.Cancell(
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

                    result = SaleReturnData.CancellSalesReturns(
                        con, 
                        trans, 
                        InvoiceResult.Data.SaleInvoiceID);

                    _ThrowException(result);

                    result = CashTransactionData.CancellSalesReturnsTransactions(
                        con,
                        trans,
                        InvoiceResult.Data.SaleInvoiceID);

                    _ThrowException(result);

                    result = ProductData.DecreaseStockAfterCancellInvoiceReturns(
                        con,
                        trans,
                        InvoiceResult.Data.SaleInvoiceID);

                    _ThrowException(result);
                });

            if (TransResult.IsSuccess)
            {
                LogManager.LogInfo($"تمت عملية إلغاء فاتورة البيع {id} بنجاح.");

                return Result.Success("تمت عملية الإلغاء بنجاح.");
            }

            return Result.Failure("فشلت عملية إلغاء هذه الفاتورة!");
        }

        public static Result IsExist(int id)
        {
            Result<bool> result = SaleInvoiceData.IsExist(id);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return Result.Success();

                return Result.Failure("هذه الفاتورة غير مسجلة في هذا النظام!");
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

            Result<int> result = SaleInvoiceData.GetCount(
                filterMethodIndex,
                filterValue,
                cancelled);

            if (result.IsSuccess)
                return result;

            return Result<int>.Failure("فشلت عملية الحصول على عدد فواتير البيع!");
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

            Result<DataTable> result = SaleInvoiceData.GetInvoices(
                offset,
                pageSize,
                filterMethodIndex,
                filterValue,
                cancelled);

            if (result.IsSuccess)
                return result;

            return Result<DataTable>.Failure(
                "فشلت عملية الحصول على جميع فواتير البيع!");
        }

        public static Result<bool> HasReturns(int id)
        {
            Result<bool> result = SaleInvoiceData.HasReturns(id);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return result;

                return Result<bool>.Failure("هذه الفاتورة ليس لها مرتجعات!");
            }

            return Result<bool>.Failure(
                "فشلت عملية التحقق من وجود مرتجعات لهذه الفاتورة!");
        }
    }
}

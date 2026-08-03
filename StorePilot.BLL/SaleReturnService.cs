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
    public class SaleReturnService : BaseBusiness
    {
        public SaleReturnModel Model { get; private set; }

        private List<SaleReturnItemModel> _Items { get; set; }

        public SaleReturnService()
        {
            this.Model = new SaleReturnModel();
            this._Items = new List<SaleReturnItemModel>();
            this.Mode = Mode.AddNew;
        }

        public SaleReturnService(SaleReturnModel model)
        {
            this.Model = model;
            this.Mode = Mode.Update;
        }

        public void SetItems(IEnumerable<SaleReturnItemModel> items)
        {
            _Items.Clear();

            _Items.AddRange(items);
        }

        public static Result<SaleReturnService> Find(int id)
        {
            Result<SaleReturnModel> result = SaleReturnData.Find(id);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                    return Result<SaleReturnService>.Success(
                        new SaleReturnService(result.Data)
                        );

                return Result<SaleReturnService>.Failure(
                    "فاتورة المرتجع هذه غير مسجلة في النظام!");
            }

            return Result<SaleReturnService>.Failure(
                "فشلت عملية الوصول لفاتورة المرتجع هذه!");
        }

        protected override Result _AddNew()
        {
            var SaleInvoiceResult = SaleInvoiceData.Find(this.Model.SaleInvoiceID);

            if (!SaleInvoiceResult.IsSuccess || SaleInvoiceResult.Data == null)
                return Result.Failure("فاتورة البيع هذه غير مسجلة في النظام," +
                    " أو فشلت عملية الوصول لبيانات الفاتورة");

            Result TransResult = DbManager.Current?.ExecuteTransaction(
                (con, trans) =>
                {
                    CashTransactionModel TransModel = new CashTransactionModel();

                    TransModel.TransactionDate = Model.ReturnDate;
                    TransModel.PaidAmount = Model.TotalReturnAmount;
                    TransModel.Description = "مصروفات فاتورة مرتجع";

                    Result result = CashTransactionData.AddNew(
                        con,
                        trans,
                        TransModel);

                    _ThrowException(result);

                    Model.TransactionID = TransModel.TransactionID;

                    result = SaleReturnData.AddNew(
                        con,
                        trans,
                        Model);

                    _ThrowException(result);

                    foreach (SaleReturnItemModel item in _Items)
                    {
                        result = SaleReturnItemData.AddNew(con, trans, item);

                        _ThrowException(result);
                    }

                    result = InvoiceData.UpdateTotalAmountAfterCreatingReturns(
                        con,
                        trans,
                        this.Model.ReturnID);

                    _ThrowException(result);

                    result = InvoiceData.UpdateStatus(
                        con,
                        trans,
                        SaleInvoiceResult.Data.InvoiceID);

                    _ThrowException(result);

                    result = ProductData.IncreaseStockAfterReturns(
                        con,
                        trans,
                        this.Model.ReturnID);

                    _ThrowException(result);

                    result = InvoiceItemData.UpdateInvoiceItems(
                        con,
                        trans,
                        this.Model.ReturnID,
                        SaleInvoiceResult.Data.InvoiceID);

                    _ThrowException(result);
                });

            if (TransResult.IsSuccess)
            {
                LogManager.LogInfo($"تمت عملية إضافة فاتورة المرتجع " +
                    $"{Model.ReturnID} هذه بنجاح.");

                return Result.Success(
                    "تمت عملية حفظ بيانات فاتورة المرتجع هذه بنجاح.");
            }

            return Result.Failure("فشلت عملية حفظ بيانات فاتورة المرتجع هذه!");
        }

        protected override Result _Update()
        {
            return Result.Failure("لا يسمح بتعديل أي فاتورة مرتجع في النظام," +
                " يرجى إلغاء الفاتورة وإنشاء أخرى جديدة!");
        }

        public override Result Valid()
        {
            Result result = this.ValidateReturnDate();

            if (!result.IsSuccess)
                return Result.Failure(result.Message);

            result = this.ValidateItems();

            if (!result.IsSuccess)
                return Result.Failure(result.Message);

            this.Model.TotalReturnAmount = _Items.Sum(item => item.TotalPrice);

            result = this.ValidateTotalReturnAmount();

            if (!result.IsSuccess)
                return Result.Failure(result.Message);

            return result;
        }

        public Result ValidateItems()
        {
            if (!Guard.HasItems(_Items))
                return Result.Failure("لا يسمح بإنشاء فاتورة مرتجع بدون أية عناصر!");

            foreach(SaleReturnItemModel item in _Items)
            {
                var result = InvoiceItemData.GetSaleInvoiceItem(
                    this.Model.SaleInvoiceID,
                    item.ProductID);

                if (!result.IsSuccess || result.Data == null)
                    return Result.Failure("فشلت عملية الوصول لبيانات صنف في المرتجع " +
                        "أو أن الصنف غير مسجل في فاتورة البيع!");

                if (_Items.Count(i => i.ProductID == item.ProductID) > 1)
                    return Result.Failure("هناك صنف مكرر في الفاتورة!");

                if (item.Quantity <= 0)
                    return Result.Failure(
                        "يوجد عنصر الكمية المطلوبة منه أصغر من أو تساوي الصفر!");

                if (item.Quantity > result.Data.Quantity)
                    return Result.Failure(
                        "يوجد عنصر الكمية المطلوبة منه " +
                        "أكبر من الكمية المسجلة في الفاتورة!");

                item.UnitPrice = result.Data.UnitPrice;
            }

            return Result.Success();
        }

        public Result ValidateReturnDate()
        {
            var result = SaleInvoiceData.Find(this.Model.SaleInvoiceID);

            if (result.IsSuccess)
            {
                if (result.Data == null)
                    return Result.Failure("فاتورة البيع غير مسجلة في النظام!");

                if (this.Model.ReturnDate < result.Data.InvoiceDate)
                    return Result.Failure(
                        "يجب إن يكون تاريخ فاتورة المرتجع أكبر من" +
                        " أو يساوي تاريخ فاتورة البيع!");
            }
            else
                return Result.Failure("فشلت عملية الوصول لبيانات فاتورة البيع!");

            return Result.Success();
        }

        public Result ValidateTotalReturnAmount()
        {
            var result = SaleInvoiceData.Find(this.Model.SaleInvoiceID);

            if (result.IsSuccess)
            {
                if (result.Data == null)
                    return Result.Failure("فاتورة البيع غير مسجلة في النظام!");

                if (result.Data.InvoiceStatus == InvoiceStatus.Deferred.ToArabic()
                    && result.Data.TotalAmount - this.Model.TotalReturnAmount <
                    result.Data.PaidAmount)
                    return Result.Failure(
                        "يجب أن يكون مجموع الدفعات أصغر من " +
                        "أو يساوي إجمالي الفاتورة بعد المرتجع!");
            }
            if(!result.IsSuccess)
                return Result.Failure("فشلت عملية الوصول لبيانات فاتورة البيع!");

            return Result.Success();
        }

        public static Result Cancell(int id)
        {
            Result<SaleReturnModel> SaleReturnResult = SaleReturnData.Find(id);

            if (!SaleReturnResult.IsSuccess || SaleReturnResult.Data == null)
                return Result.Failure("فشلت عملية الوصول لبيانات فاتورة المرتجع " +
                    "أو أن الفاتورة غير مسجلة في النظام!");

            if (SaleReturnResult.Data.Cancelled)
                return Result.Failure("فاتورة المرتجع هذه ملغية بالفعل!");

            Result<bool> HasPaymentsResult = InvoiceData.HasPayments(id);

            if (!HasPaymentsResult.IsSuccess)
                return Result.Failure("فشلت عملية التحقق من كون الفاتورة لها سجل دفع!");

            Result<SaleInvoiceModel> SaleInvoiceResult = 
                SaleInvoiceData.Find(SaleReturnResult.Data.SaleInvoiceID);

            if (!SaleInvoiceResult.IsSuccess || SaleInvoiceResult.Data == null)
                return Result.Failure("فشلت عملية الوصول لبيانات فاتورة البيع " +
                    "أو أن الفاتورة غير مسجلة في النظام!");

            Result TransResult = DbManager.Current?.ExecuteTransaction((con, trans) =>
            {
                /*
                 * لو مدفوع وليس لها سجل دفع يتم تحدث إجمالي الفاتورة والمبلغ المدفوع
                 * لو مدفوع ولها سجل دفع يتم تحديث إجمالي الفاتورة وحالة الفاتورة لآجل
                 * لو آجل يتم تحديث إجمالي الفاتورة
                 */
                Result result = SaleReturnData.Cancell(
                            con,
                            trans,
                            id);

                _ThrowException(result);

                result = CashTransactionData.Cancell(
                    con,
                    trans,
                    SaleReturnResult.Data.TransactionID);

                _ThrowException(result);

                result = ProductData.DecreaseStockAfterCancellReturns(
                    con,
                    trans,
                    id);

                _ThrowException(result);

                result = InvoiceData.UpdateTotalAmountAfterCancellingReturns(
                    con,
                    trans,
                    id);

                _ThrowException(result);

                if (SaleInvoiceResult.Data.InvoiceStatus == InvoiceStatus.Paid.ToArabic())
                {
                    if (HasPaymentsResult.Data)
                    {
                        result = InvoiceData.UpdateStatus(
                            con, 
                            trans, 
                            SaleInvoiceResult.Data.InvoiceID);

                        _ThrowException(result);
                    }
                    else
                    {
                        result = InvoiceData.UpdatePaidAmountAfterCancellReturns(
                            con, 
                            trans, 
                            SaleInvoiceResult.Data.InvoiceID);

                        _ThrowException(result);
                    }
                }
            });

            if (!TransResult.IsSuccess)
                return Result.Failure("فشلت عملية إلغاء فاتورة المرتجع!");

            return Result.Success("تمت عملية إلغاء فاتورة المرتجع بنجاح.");
        }

        public static Result IsExist(int id)
        {
            Result<bool> result = SaleReturnData.IsExist(id);

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
            int saleInvoiceId,
            int filterMethodIndex,
            string filterValue,
            bool cancelled)
        {
            Result<int> result = SaleReturnData.GetCount(
                saleInvoiceId,
                filterMethodIndex,
                filterValue,
                cancelled);

            if (result.IsSuccess)
                return result;

            return Result<int>.Failure("فشلت عملية الحصول على عدد فواتير المرتجعات!");
        }

        public static Result<DataTable> GetReturns(
            int saleInvoiceId,
            int currentPage,
            int pageSize,
            int filterMethodIndex,
            string filterValue,
            bool cancelled)
        {
            int offset = (currentPage - 1) * pageSize;

            Result<DataTable> result = SaleReturnData.GetInvoices(
                saleInvoiceId,
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
    }
}

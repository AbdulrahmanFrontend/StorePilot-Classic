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
            _Items = new List<SaleReturnItemModel>();
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

        public static Result<SaleReturnService> GetByID(int id)
        {
            Result<SaleReturnModel> result = SaleReturnData.GetByID(id);

            if (result.IsSuccess)
            {
                if (result.Data == null)
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
            var InvoiceIDResult = SaleInvoiceData.GetByID(this.Model.SaleInvoiceID);

            if (!InvoiceIDResult.IsSuccess || InvoiceIDResult.Data == null)
                return Result.Failure(InvoiceIDResult.Message);

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

                    result = SaleInvoiceData.UpdatePaidAmount(
                        con,
                        trans,
                        this.Model.ReturnID);

                    _ThrowException(result);

                    result = InvoiceData.UpdateStatus(
                        con,
                        trans,
                        InvoiceIDResult.Data.InvoiceID);

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

                if (result.IsSuccess && result.Data == null)
                    return Result.Failure("هذا العنصر ليس موجودا ضمن فاتورة البيع!");
                else if (!result.IsSuccess)
                    return Result.Failure(
                        "فشلت عملية الوصول لعنصر من عناصر فاتورة البيع!");

                if (item.Quantity <= 0)
                    return Result.Failure(
                        "يوجد عنصر الكمية المطلوبة منه أصغر من أو تساوي الصفر!");

                if (item.Quantity > result.Data.Quantity)
                    return Result.Failure(
                        "يوجد عنصر الكمية المطلوبة منه " +
                        "أكبر من الكمية المتوفرة في المخزن!");

                item.UnitPrice = result.Data.UnitPrice;
            }

            return Result.Success();
        }

        public Result ValidateReturnDate()
        {
            var result = SaleInvoiceData.GetByID(this.Model.SaleInvoiceID);

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
            var result = SaleInvoiceData.GetByID(this.Model.SaleInvoiceID);

            if (result.IsSuccess)
            {
                if (result.Data == null)
                    return Result.Failure(result.Message);

                if (result.Data.InvoiceStatus == InvoiceStatus.Deferred.ToArabic()
                    && result.Data.TotalAmount - this.Model.TotalReturnAmount <
                    result.Data.PaidAmount)
                    return Result.Failure(
                        "يجب أن يكون مجموع الدفعات أصغر من " +
                        "أو يساوي إجمالي الفاتورة بعد المرتجع!");
            }

            return Result.Success();
        }
    }
}

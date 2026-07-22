using DevToolkit.Core;
using DevToolkit.Core.Common;
using DevToolkit.Core.Guards;
using DevToolkit.Core.Results;
using DevToolkit.Data.Core;
using DevToolkit.Logging.Managers;
using StorePilot.Core.Models;
using StorePilot.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.BLL
{
    public class PurchaseInvoiceService : BaseBusiness
    {
        public PurchaseInvoiceModel Model { get; private set; }

        public PurchaseInvoiceService()
        {
            this.Model = new PurchaseInvoiceModel();
            this.Mode = Mode.AddNew;
        }

        public PurchaseInvoiceService(PurchaseInvoiceModel model)
        {
            this.Model = model;
            this.Mode = Mode.Update;
        }

        public static Result<PurchaseInvoiceService> GetByID(int id)
        {
            Result<PurchaseInvoiceModel> result = PurchaseInvoiceData.GetByID(id);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                    return Result<PurchaseInvoiceService>.Success(
                        new PurchaseInvoiceService(result.Data)
                        );

                return Result<PurchaseInvoiceService>.Failure(
                    "هذه الفاتورة غير مسجلة في هذا النظام!");
            }

            return Result<PurchaseInvoiceService>.Failure(
                "فشلت عملية الوصول لبيانات هذه الفاتورة!");
        }

        protected override Result _AddNew()
            => Result.Failure("لا يسمح بإنشاء فاتورة بدون عناصر!");

        //protected Result _AddNew(BindingList<InvoiceItemModel> items)
        //{
        //    if (this.Model.SupplierID == 0)
        //        return Result.Failure("رجاءا اختيار مورد أولا!");

        //    var result = SupplierService.IsFound(this.Model.SupplierID);

        //    if (!result.IsSuccess)
        //        return result;

        //    result = ValidateItems(items);

        //    if (!result.IsSuccess)
        //        return result;

        //    this.Model.TotalAmount = items.Sum(i => i.TotalPrice);

        //    var AddNewResult = DbManager.Current?.ExecuteTransaction((con, trans) =>
        //    {
        //        var transModel = new CashTransactionModel
        //        {
        //            TransactionDate = Model.PurchaseDate,
        //            TransactionType = TransactionType.Expense.ToArabic(),
        //            Amount = Model.TotalAmount,
        //            Description = $"مصروفات فاتورة شراء"
        //        };

        //        var transResult = CashTransactionData.AddNewPurchaseTransaction(
        //            con,
        //            trans,
        //            transModel);

        //        _ThrowException(transResult);

        //        this.Model.TransactionID = transModel.TransactionID;

        //        var invoiceResult = PurchaseInvoiceData.AddNew(con, trans, Model);

        //        _ThrowException(invoiceResult);

        //        foreach (var item in items)
        //        {
        //            var itemResult = PurchaseInvoiceItemData.AddNew(
        //                con,
        //                trans,
        //                Model.PurchaseID,
        //                item);

        //            _ThrowException(itemResult);
        //        }

        //        var stockResult = ProductData.IncreaseQuantityForPurchaseInvoice(
        //                con,
        //                trans,
        //                this.Model.PurchaseID);

        //        _ThrowException(stockResult);
        //    });

        //    if (AddNewResult.IsSuccess)
        //    {
        //        LogManager.LogInfo(
        //            $"تمت عملية حفظ فاتورة الشراء {Model.PurchaseID} بنجاح.");
        //        return Result.Success("تمت عملية حفظ الفاتورة بنجاح.");
        //    }

        //    return Result.Failure("فشلت عملية حفظ الفاتورة!");
        //}

        //public Result Save(BindingList<InvoiceItemModel> items) => _AddNew(items);

        protected override Result _Update()
        {
            return Result.Failure(
                "لا يسمح بتحديث أي فاتورة" +
                " عليك إلغاء هذه الفاتورة ثم إنشاء فاتورة جديدة!");
        }

        //public static Result ValidateItems(BindingList<InvoiceItemModel> items)
        //{
        //    if (!Guard.HasItems(items))
        //        return Result.Failure("يجب إضافة عناصر للفاتورة أولا!");

        //    foreach (var item in items)
        //    {
        //        var result = ProductService.IsFound(item.ProductID);

        //        if (!result.IsSuccess) return result;

        //        if (item.RequiredQuantity <= 0)
        //            return Result.Failure("هناك منتج الكمية المطلوبة منه غير صالحة!");

        //        if (item.UnitPrice <= 0)
        //            return Result.Failure("هناك منتج سعره غير صالح!");
        //    }

        //    return Result.Success();
        //}

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
                    Result result = ProductData.DecreaseStock(con,trans, invoiceId);

                    _ThrowException(result);

                    result = PurchaseInvoiceData.Cancell(con, trans, invoiceId);

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
                LogManager.LogInfo($"تمت عملية إلغاء فاتورة الشراء {invoiceId} بنجاح.");

                return Result.Success("تمت عملية الإلغاء بنجاح.");
            }

            return Result.Failure("فشلت عملية إلغاء هذه الفاتورة!");
        }

        public static Result IsFound(int id)
        {
            Result<bool> result = PurchaseInvoiceData.IsFound(id);

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
            Result<int> result = PurchaseInvoiceData.GetCount();

            if (result.IsSuccess)
                return result;

            return Result<int>.Failure("فشلت عملية الحصول على عدد فواتير الشراء!");
        }

        public static Result<int> GetCount(
            int filterMethodIndex,
            string filterValue)
        {
            Result<int> result = PurchaseInvoiceData.GetCount(
                filterMethodIndex,
                filterValue);

            if (result.IsSuccess)
                return result;

            return Result<int>.Failure("فشلت عملية الحصول على عدد فواتير الشراء!");
        }

        public static Result<DataTable> GetInvoices(
            int currentPage,
            int pageSize,
            int filterMethodIndex,
            string filterValue)
        {
            int offset = (currentPage - 1) * pageSize;

            Result<DataTable> result = PurchaseInvoiceData.GetInvoices(
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
                "فشلت عملية الحصول على جميع فواتير الشراء!");
        }

        public static Result<bool> IsCancelled(int id)
        {
            Result<bool> result = PurchaseInvoiceData.IsCancelled(id);

            if (result.IsSuccess)
                return result;

            return Result<bool>.Failure("فشلت عملية التحقق من إلغاء هذه الفاتورة!");
        }
    }
}

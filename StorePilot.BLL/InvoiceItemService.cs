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
    public class InvoiceItemService
    {
        public InvoiceItemModel Model { get; private set; }

        public InvoiceItemService()
        {
            Model = new InvoiceItemModel();
        }

        private InvoiceItemService(InvoiceItemModel model)
        {
            Model = model;
        }

        public static Result<InvoiceItemService> Find(int saleInvoiceId, int productId)
        {
            var result = InvoiceItemData.GetSaleInvoiceItem(saleInvoiceId, productId);

            if (result.IsSuccess)
            {
                if (result.Data == null)
                    return Result<InvoiceItemService>.Failure(
                        "هذا العنصر غير مسجل في فاتورة البيع!");

                return Result<InvoiceItemService>.Success(
                    new InvoiceItemService(result.Data)
                    );
            }

            return Result<InvoiceItemService>.Failure(
                        "فشلت عملية الوصول لبيانات هذا العنصر في فاتورة البيع!");
        }

        public static Result<DataTable> GetInvoiceItems(int invoiceId)
        {
            Result<DataTable> result = InvoiceItemData.GetInvoiceItems(invoiceId);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                    return result;

                return Result<DataTable>.Failure(
                    "هذه الفاتورة لا تحتوي على أية عناصر!");
            }

            return Result<DataTable>.Failure(
                "فشلت عملية الحصول على عناصر الفاتورة!");
        }
    }
}

using DevToolkit.Core.Results;
using StorePilot.Core.Printing;
using StorePilot.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.BLL
{
    public static class PrintService
    {
        public static Result<PrintableSalesInvoice> GetSalesInvoiceForPrint(
            int saleInvoiceId)
        {
            var result = PrintData.GetSalesInvoiceForPrint(saleInvoiceId);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                    return result;

                return Result<PrintableSalesInvoice>.Failure(
                    "هذه الفاتورة غير مسجلة في النظام!");
            }

            return Result<PrintableSalesInvoice>.Failure(
                "فشلت عملية الوصول لبيانات تلك الفاتورة!");
        }

        public static Result<PrintablePurchaseInvoice> GetPurchaseInvoiceForPrint(
            int purchaseInvoiceId)
        {
            var result = PrintData.GetPurchaseInvoiceForPrint(purchaseInvoiceId);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                    return result;

                return Result<PrintablePurchaseInvoice>.Failure(
                    "هذه الفاتورة غير مسجلة في النظام!");
            }

            return Result<PrintablePurchaseInvoice>.Failure(
                "فشلت عملية الوصول لبيانات تلك الفاتورة!");
        }

        public static Result<PrintableSalesReturn> GetSalesReturnForPrint(int returnId)
        {
            var result = PrintData.GetSalesReturnForPrint(returnId);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                    return result;

                return Result<PrintableSalesReturn>.Failure(
                    "هذه الفاتورة غير مسجلة في النظام!");
            }

            return Result<PrintableSalesReturn>.Failure(
                "فشلت عملية الوصول لبيانات تلك الفاتورة!");
        }

        public static Result<PrintablePaymentReceipt> GetPaymentReceiptForPrint(
            int paymentId)
        {
            var result = PrintData.GetPaymentReceiptForPrint(paymentId);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                    return result;

                return Result<PrintablePaymentReceipt>.Failure(
                    "عملية الدفع هذه غير مسجلة في النظام!");
            }

            return Result<PrintablePaymentReceipt>.Failure(
                "فشلت عملية الوصول لبيانات عملية الدفع هذه!");
        }
    }
}

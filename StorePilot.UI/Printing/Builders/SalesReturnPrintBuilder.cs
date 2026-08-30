using StorePilot.Core.Printing;
using StorePilot.UI.Printing.PrintDocumentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.UI.Printing.Builders
{
    public static class SalesReturnPrintBuilder
    {
        public static TablePrintDocument Build(PrintableSalesReturn salesReturn, string shopName)
        {
            var model = new PrintDocumentModel
            {
                ShopName = shopName,
                DocumentTitle = "إذن مرتجع مبيعات",

                ReferenceLines = new List<(string, string)>
                {
                    ("رقم إذن المرتجع", salesReturn.ReturnID.ToString()),
                    ("رقم فاتورة البيع الأصلية", salesReturn.RelatedSaleInvoiceReferenceID.ToString())
                },

                HeaderInfoLines = new List<(string, string)>
                {
                    ("التاريخ", salesReturn.ReturnDate.ToString("yyyy/MM/dd  hh:mm tt"))
                },

                Columns = new List<PrintColumn>
                {
                    new PrintColumn { Header = "المجموعة",   WidthPercent = 16, ValueSelector = o => ((PrintableLineItem)o).GroupName },
                    new PrintColumn { Header = "الوحدة",     WidthPercent = 10, ValueSelector = o => ((PrintableLineItem)o).UnitName },
                    new PrintColumn { Header = "الصنف",      WidthPercent = 30, ValueSelector = o => ((PrintableLineItem)o).ProductName },
                    new PrintColumn { Header = "الكمية",     WidthPercent = 12, ValueSelector = o => ((PrintableLineItem)o).Quantity.ToString("0.##") },
                    new PrintColumn { Header = "سعر الوحدة", WidthPercent = 16, ValueSelector = o => ((PrintableLineItem)o).UnitPrice.ToString("N2") },
                    new PrintColumn { Header = "الإجمالي",   WidthPercent = 16, ValueSelector = o => ((PrintableLineItem)o).TotalPrice.ToString("N2") },
                },
                Rows = salesReturn.Items.Cast<object>().ToList(),

                SummaryLines = new List<(string, string)>
                {
                    ("إجمالي قيمة المرتجع", salesReturn.TotalReturnAmount.ToString("N2"))
                },

                FooterNote = string.IsNullOrWhiteSpace(salesReturn.Notes) ? null : "ملاحظات: " + salesReturn.Notes
            };

            return new TablePrintDocument(model);
        }
    }
}

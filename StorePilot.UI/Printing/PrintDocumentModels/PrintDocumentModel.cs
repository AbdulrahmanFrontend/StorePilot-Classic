using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.UI.Printing.PrintDocumentModels
{
    /// <summary>
    /// Fully describes ONE printable document (invoice / return / receipt) in a way
    /// that is completely decoupled from GDI+ drawing code. Build one of these per
    /// document type and hand it to <see cref="TablePrintDocument"/>.
    /// </summary>
    public class PrintDocumentModel
    {
        /// <summary>Shown at the very top of every page (shop/company name).</summary>
        public string ShopName { get; set; }

        /// <summary>e.g. "فاتورة مبيعات", "فاتورة مشتريات", "إيصال سداد", "إذن مرتجع".</summary>
        public string DocumentTitle { get; set; }

        /// <summary>
        /// One or more (Label, Value) reference numbers shown prominently near the top,
        /// e.g. ("رقم فاتورة البيع", "128") and ("الرقم العام للفاتورة", "241").
        /// Printing more than one reference number is intentional — it's what lets the
        /// customer (or you) cross-check a printed slip against the database and catch forgeries.
        /// </summary>
        public List<(string Label, string Value)> ReferenceLines { get; set; } = new List<(string, string)>();

        /// <summary>Short info lines under the title — date, customer/supplier name, status, etc.</summary>
        public List<(string Label, string Value)> HeaderInfoLines { get; set; } = new List<(string, string)>();

        /// <summary>Main items table. Leave both Columns and Rows empty to skip the table entirely (e.g. a payment receipt).</summary>
        public List<PrintColumn> Columns { get; set; } = new List<PrintColumn>();
        public List<object> Rows { get; set; } = new List<object>();

        /// <summary>Totals block printed right after the table — (label, value) pairs, e.g. الإجمالي / المدفوع / المتبقي.</summary>
        public List<(string Label, string Value)> SummaryLines { get; set; } = new List<(string, string)>();

        /// <summary>Optional secondary table (e.g. payment history), printed after the summary lines.</summary>
        public PrintSubSection ExtraSection { get; set; }

        /// <summary>Free-text line printed at the very bottom, e.g. "شكراً لتعاملكم معنا".</summary>
        public string FooterNote { get; set; }
    }
}

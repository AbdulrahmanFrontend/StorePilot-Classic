using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.UI.Printing.PrintDocumentModels
{
    /// <summary>
    /// An optional secondary table printed under the main one — e.g. the list of
    /// installment payments printed underneath a sales/purchase invoice.
    /// </summary>
    public class PrintSubSection
    {
        public string Title { get; set; }
        public List<PrintColumn> Columns { get; set; } = new List<PrintColumn>();
        public List<object> Rows { get; set; } = new List<object>();
    }
}

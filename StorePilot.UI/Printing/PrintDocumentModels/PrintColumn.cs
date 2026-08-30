using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.UI.Printing.PrintDocumentModels
{
    /// <summary>
    /// Describes one column of a printed table: its header text, its relative
    /// width (percentages across all columns, does not need to sum to exactly 100 —
    /// the engine normalizes automatically), and how to read the cell text out of a row object.
    /// </summary>
    public class PrintColumn
    {
        public string Header { get; set; }
        public float WidthPercent { get; set; }
        public Func<object, string> ValueSelector { get; set; }
    }
}

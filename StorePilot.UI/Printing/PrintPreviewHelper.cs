using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorePilot.UI.Printing
{
    /// <summary>
    /// Thin, reusable wrapper around PrintPreviewDialog / PrintDialog so every screen
    /// in the app previews/prints the same way. Not specific to any document type —
    /// works with any System.Drawing.Printing.PrintDocument.
    ///
    /// IMPORTANT (per project convention): always preview before sending to paper,
    /// and never call this from inside a database transaction — a printer failure
    /// (out of paper, offline, etc.) must never roll back an already-saved sale/payment.
    /// Call this AFTER the BLL/DAL save has already committed successfully.
    /// </summary>
    public static class PrintPreviewHelper
    {
        /// <summary>Opens the standard preview dialog. The dialog's own Print button calls document.Print().</summary>
        public static void Show(PrintDocument document, string dialogTitle = "معاينة الطباعة")
        {
            if (document == null) throw new ArgumentNullException(nameof(document));

            using (var previewDialog = new PrintPreviewDialog())
            {
                previewDialog.Document = document;
                previewDialog.Text = dialogTitle;
                previewDialog.RightToLeftLayout = true;
                previewDialog.RightToLeft = RightToLeft.Yes;
                previewDialog.WindowState = FormWindowState.Maximized;
                previewDialog.ShowDialog();
            }
        }

        /// <summary>
        /// Skips the preview and goes straight to the Windows "Print" dialog (choose printer,
        /// copies, etc.) then prints. Use for quick re-prints where a preview isn't needed —
        /// the default recommendation is still <see cref="Show"/>.
        /// </summary>
        public static bool TryPrintDirectly(PrintDocument document, out string errorMessage)
        {
            if (document == null) throw new ArgumentNullException(nameof(document));
            errorMessage = null;

            try
            {
                using (var printDialog = new PrintDialog { Document = document })
                {
                    if (printDialog.ShowDialog() != DialogResult.OK)
                        return false;

                    document.Print();
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}

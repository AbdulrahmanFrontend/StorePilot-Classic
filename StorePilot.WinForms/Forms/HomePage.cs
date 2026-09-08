using Krypton.Toolkit;
using StorePilot.WinForms.Theme;
using System.Drawing;
using System.Windows.Forms;

namespace StorePilot.WinForms.Forms
{
    /// <summary>
    /// الصفحة الرئيسية المؤقتة للـ Shell.
    /// لاحقاً يمكن تحويلها إلى Dashboard حقيقي.
    /// </summary>
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();

            ApplyTheme();
        }

        public void ApplyTheme()
        {
            rootPanel.StateCommon.Color1 = AppTheme.Surface;

            titleLabel.StateCommon.ShortText.Color1 =
                AppTheme.Text;

            descriptionLabel.StateCommon.ShortText.Color1 =
                AppTheme.SecondaryText;
        }
    }
}

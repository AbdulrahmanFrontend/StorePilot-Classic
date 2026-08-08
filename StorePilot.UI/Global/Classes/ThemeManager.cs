using DevToolkit.BaseWinForms.Theming;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.UI.Global.Classes
{
    public static class ThemeManager
    {
        public static Themes CurrentTheme { get; set; } = Themes.Light;

        public static void ApplyTheme()
        {
            switch (CurrentTheme)
            {
                case Themes.Light:
                    Theme.Primary = Color.FromArgb(37, 99, 235); // الأزرق الرئيسي
                    Theme.Background = Color.FromArgb(248, 250, 252); // خلفية البرنامج
                    Theme.Surface = Color.White; // البطاقات والنوافذ
                    Theme.Border = Color.FromArgb(226, 232, 240); // الحدود
                    Theme.Text = Color.FromArgb(30, 41, 59); // النص الأساسي
                    Theme.TextSecondary = Color.FromArgb(100, 116, 139); // النص الثانوي
                    Theme.Success = Color.FromArgb(22, 163, 74); // نجاح
                    Theme.Warning = Color.FromArgb(245, 158, 11); // تحذير
                    Theme.Danger = Color.FromArgb(220, 38, 38); // حذف / أخطاء
                    break;
                case Themes.Dark:
                    Theme.Primary = Color.FromArgb(59, 130, 246); // الأزرق الرئيسي
                    Theme.Background = Color.FromArgb(15, 23, 42); // خلفية البرنامج
                    Theme.Surface = Color.FromArgb(30, 41, 59); // البطاقات والنوافذ
                    Theme.Border = Color.FromArgb(51, 65, 85); // الحدود
                    Theme.Text = Color.FromArgb(248, 250, 252); // النص الأساسي
                    Theme.TextSecondary = Color.FromArgb(203, 213, 225); // النص الثانوي
                    Theme.Success = Color.FromArgb(34, 197, 94); // نجاح
                    Theme.Warning = Color.FromArgb(251, 191, 36); // تحذير
                    Theme.Danger = Color.FromArgb(239, 68, 68); // حذف / أخطاء
                    break;
            }
        }
    }
}

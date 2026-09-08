using System;
using Krypton.Toolkit;
using StorePilot.WinForms.Foundation;

namespace StorePilot.WinForms.Forms
{
    /// <summary>
    /// Same setup screen, but used from inside the running application.
    /// This is deliberate: first-run setup and later editing should share the same
    /// rules and UI instead of becoming two separate implementations.
    /// </summary>
    public sealed class ShopSettingsForm : ShopSetupForm
    {
        public ShopSettingsForm(AppBrandSettingsStore settingsStore)
            : base(settingsStore)
        {
            Text = "إعدادات المحل";
        }
    }
}

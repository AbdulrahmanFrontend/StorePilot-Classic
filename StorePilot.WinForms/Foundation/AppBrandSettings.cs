using System;

namespace StorePilot.WinForms.Foundation
{
    /// <summary>
    /// The small piece of application state that belongs to the shop branding.
    /// It intentionally contains no database objects and no UI controls.
    /// </summary>
    public sealed class AppBrandSettings
    {
        public string ShopName { get; set; } = string.Empty;

        // This is the display name of the current user, not an authentication account.
        public string UserDisplayName { get; set; } = string.Empty;

        // The actual image is stored separately as a file.
        // Keeping only its path here makes replacing/deleting the logo easy.
        public string LogoFileName { get; set; } = string.Empty;

        public bool IsConfigured =>
            !string.IsNullOrWhiteSpace(ShopName) &&
            !string.IsNullOrWhiteSpace(UserDisplayName);
    }
}

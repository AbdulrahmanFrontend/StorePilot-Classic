using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace StorePilot.WinForms.Foundation
{
    /// <summary>
    /// Generates a clean fallback logo when the customer does not provide one.
    /// This avoids forcing the customer to upload an image during setup.
    /// </summary>
    public static class BrandingImageHelper
    {
        public static Bitmap CreateDefaultLogo(string shopName, int size = 180)
        {
            var bitmap = new Bitmap(size, size);

            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.Clear(Color.White);

                using (var brush = new SolidBrush(Color.FromArgb(36, 99, 235)))
                {
                    graphics.FillRoundedRectangle(
                        brush, 
                        12,
                        12, 
                        size - 24, 
                        size - 24, 
                        24);
                }

                var initials = GetInitials(shopName);

                using (var font = new Font("Segoe UI", Math.Max(20, size / 4.5f), FontStyle.Bold))
                using (var textBrush = new SolidBrush(Color.White))
                {
                    var textSize = graphics.MeasureString(initials, font);
                    var x = (size - textSize.Width) / 2f;
                    var y = (size - textSize.Height) / 2f;

                    graphics.DrawString(initials, font, textBrush, x, y);
                }
            }

            return bitmap;
        }

        private static string GetInitials(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "SP";

            var parts = text.Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 1)
                return parts[0].Substring(0, Math.Min(2, parts[0].Length)).ToUpperInvariant();

            return (parts[0][0].ToString() + parts[parts.Length - 1][0]).ToUpperInvariant();
        }

        private static void FillRoundedRectangle(
            this Graphics graphics,
            Brush brush,
            float x,
            float y,
            float width,
            float height,
            float radius)
        {
            using (var path = new GraphicsPath())
            {
                var diameter = radius * 2;

                path.AddArc(x, y, diameter, diameter, 180, 90);
                path.AddArc(x + width - diameter, y, diameter, diameter, 270, 90);
                path.AddArc(x + width - diameter, y + height - diameter, diameter, diameter, 0, 90);
                path.AddArc(x, y + height - diameter, diameter, diameter, 90, 90);
                path.CloseFigure();

                graphics.FillPath(brush, path);
            }
        }
    }
}

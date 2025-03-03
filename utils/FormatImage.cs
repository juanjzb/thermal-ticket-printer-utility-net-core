using System.Drawing;

namespace ThermalPrinterLibrary_CSharp.utils
{
    public static class FormatImage
    {
        public static Image ResizeLogo(Image logo, int newHeight)
        {
            float aspectRatio = (float)logo.Width / logo.Height;
            int newWidth = (int)(newHeight * aspectRatio);

            Bitmap resizedLogo = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(resizedLogo))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(logo, 0, 0, newWidth, newHeight);
            }

            return resizedLogo;
        }
    }
}

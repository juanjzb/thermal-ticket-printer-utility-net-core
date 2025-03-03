using System.Text;

namespace ThermalPrinterLibrary_CSharp.utils
{
    public class FormatText
    {

        public static string CenterText(string text, int paperWidth)
        {
            if (string.IsNullOrEmpty(text)) return text;
            int padding = (paperWidth - text.Length) / 2;
            return text.PadLeft(padding + text.Length).PadRight(paperWidth);
        }

        public static string WrapText(string text, int maxWidth)
        {
            if (string.IsNullOrEmpty(text)) return text;

            StringBuilder wrappedText = new StringBuilder();
            string[] words = text.Split(' ');

            string line = "";
            foreach (string word in words)
            {
                if ((line + word).Length > maxWidth)
                {
                    wrappedText.AppendLine(line.Trim());
                    line = "";
                }
                line += word + " ";
            }

            if (!string.IsNullOrEmpty(line))
            {
                wrappedText.AppendLine(line.Trim());
            }

            return wrappedText.ToString().TrimEnd('\n', '\r'); ;
        }

    }
}

using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using ThermalPrinterLibrary_CSharp;
using ThermalPrinterLibrary_CSharp.utils;

public class ThermalPrinter
{
    public string BusinessName { get; set; }
    public string Ruc { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string AdditionalText { get; set; }
    public Image Logo { get; set; }
    public string CurrencySymbol { get; set; } = "$";
    public bool UseEnglish { get; set; } = false;

    private const int LogoHeight = 50;

    public void PrintInvoice(Invoice invoice, int paperWidth)
    {
        string invoiceContent = GenerateInvoiceContent(invoice, paperWidth);
        SendToPrinter(invoiceContent, paperWidth);
    }

    public string GenerateInvoiceContent(Invoice invoice, int paperWidth)
    {
        int maxCharsPerLine = 28;
        int fontSize = 8;

        if (paperWidth == 80)
        {
            maxCharsPerLine = 38;
            fontSize = 9;
        }

        StringBuilder sb = new StringBuilder();

        if (Logo == null)
        {
            sb.AppendLine("[LOGO]");
        }
        sb.AppendLine(FormatText.CenterText(BusinessName, maxCharsPerLine));
        sb.AppendLine(FormatText.CenterText(Ruc, maxCharsPerLine));
        sb.AppendLine(FormatText.CenterText(Phone, maxCharsPerLine));
        sb.AppendLine(FormatText.CenterText(Email, maxCharsPerLine));
        sb.AppendLine(FormatText.CenterText(Address, maxCharsPerLine));
        sb.AppendLine();

        sb.AppendLine(FormatText.CenterText($"FACTURA#: {invoice.InvoiceNumber}", maxCharsPerLine));
        sb.AppendLine(FormatText.CenterText($"FECHA: {invoice.Date:dd/MM/yyyy HH:mm}", maxCharsPerLine));
        sb.AppendLine();

        sb.AppendLine(FormatText.WrapText($"CLIENTE: {invoice.CustomerName}", maxCharsPerLine));
        sb.AppendLine(FormatText.WrapText($"IDENTIFICACIÓN: {invoice.CustomerId}", maxCharsPerLine));
        sb.AppendLine(FormatText.WrapText($"TELÉFONO: {invoice.CustomerPhone}", maxCharsPerLine));
        sb.AppendLine(FormatText.WrapText($"DOMICILIO: {invoice.CustomerAddress}", maxCharsPerLine));
        sb.AppendLine();

        sb.AppendLine(FormatText.WrapText($"CAJERO: {invoice.Cashier}", maxCharsPerLine));
        sb.AppendLine(FormatText.WrapText($"VENDEDOR: {invoice.Seller}", maxCharsPerLine));
        sb.AppendLine(FormatText.WrapText($"TÉRMINO: {invoice.PaymentTerm}", maxCharsPerLine));
        sb.AppendLine(FormatText.WrapText($"VENCIMIENTO: {invoice.DueDate:dd/MM/yyyy}", maxCharsPerLine));
        sb.AppendLine(FormatText.CenterText(new string('*', 10), maxCharsPerLine));

        string header = "CANT x PRECIO | DESCRIPCION | TOTAL";

        sb.AppendLine(header);
        sb.AppendLine(new string('-', maxCharsPerLine));

        foreach (var item in invoice.Items)
        {
            string productRow = $"{item.Quantity} x {CurrencySymbol.ToString()}{item.Price.ToString()} {item.ProductName} {CurrencySymbol.ToString()}{item.Total.ToString()}";
            sb.AppendLine(FormatText.WrapText(productRow, maxCharsPerLine));
        }
        sb.AppendLine(new string('-', maxCharsPerLine));

        sb.AppendLine(FormatText.WrapText($"SUBTOTAL: {CurrencySymbol.ToString()}{invoice.Subtotal.ToString().PadLeft(maxCharsPerLine - 17)}", maxCharsPerLine));
        sb.AppendLine(FormatText.WrapText($"DESCUENTO: {CurrencySymbol.ToString()}{invoice.Discount.ToString().PadLeft(maxCharsPerLine - 19)}", maxCharsPerLine));
        sb.AppendLine(FormatText.WrapText($"IVA: {CurrencySymbol.ToString()}{invoice.Tax.ToString().PadLeft(maxCharsPerLine - 13)}", maxCharsPerLine));
        sb.AppendLine(FormatText.WrapText($"TOTAL: {CurrencySymbol.ToString()} {invoice.TotalAmount.ToString().PadLeft(maxCharsPerLine - 14)}", maxCharsPerLine));
        sb.AppendLine(FormatText.WrapText($"({FormatNumber.Convert((int)invoice.TotalAmount)})", maxCharsPerLine));
        sb.AppendLine(new string('*', maxCharsPerLine));

        sb.AppendLine(FormatText.CenterText(AdditionalText, maxCharsPerLine));

        return sb.ToString();
    }

    private void SendToPrinter(string content, int paperWidth)
    {
        try
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (sender, e) =>
            {
                int fontSize = paperWidth == 55 ? 8 : 9;
                Font font = new Font("Courier New", fontSize);
                Brush brush = Brushes.Black;
                float startX = 10;
                float startY = 10;

                if (Logo != null)
                {
                    Image resizedLogo = FormatImage.ResizeLogo(Logo, LogoHeight);

                    float logoX = (e.PageBounds.Width - resizedLogo.Width) / 2;
                    e.Graphics.DrawImage(resizedLogo, logoX, startY);
                    startY += resizedLogo.Height + 10;
                }

                string[] lines = content.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                float lineHeight = font.GetHeight(e.Graphics);

                foreach (string line in lines)
                {
                    e.Graphics.DrawString(line, font, brush, startX, startY);
                    startY += lineHeight;
                }
            };

            printDoc.Print();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error al imprimir: {ex.Message}", ex);
        }
    }

}
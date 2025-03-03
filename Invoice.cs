namespace ThermalPrinterLibrary_CSharp
{
    public class Invoice
    {
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }

        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }

        public string Cashier { get; set; }
        public string Seller { get; set; }
        public string PaymentTerm { get; set; }
        public DateTime DueDate { get; set; }

        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();

        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalAmount => Subtotal - Discount + Tax;

        public Invoice()
        {
            Date = DateTime.Now;
            DueDate = Date.AddDays(30);
        }
    }

}

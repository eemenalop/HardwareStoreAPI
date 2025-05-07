namespace billingSystem.Dtos.InvoiceDtos
{
    public class CreateInvoiceDto
    {
        public DateTime Date { get; set; }
        public bool IsCanceled { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

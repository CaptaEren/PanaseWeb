namespace PanaseWeb.Dtos.Payments
{
    public class PaymentResponseDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; } // "Pending", "Completed", "Refunded"
        public string TransactionId { get; set; }
    }
}

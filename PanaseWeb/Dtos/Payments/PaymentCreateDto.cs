using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Dtos.Payments
{
    public class PaymentCreateDto
    {
        [Required] public string UserId { get; set; }
        [Required] public decimal Amount { get; set; }
        public int? AppointmentId { get; set; }
        [Required] public string PaymentMethod { get; set; } // "CreditCard", "Insurance"
    }
}

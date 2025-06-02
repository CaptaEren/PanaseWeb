using PanaseWeb.Dtos.Payments;

namespace PanaseWeb.Services.Interfaces
{
    public interface IPaymentService:IModelService<PaymentCreateDto,PaymentResponseDto>
    {
    }
}

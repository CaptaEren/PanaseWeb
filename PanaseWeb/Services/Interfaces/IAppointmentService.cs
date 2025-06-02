using PanaseWeb.Dtos.Appointments;
using PanaseWeb.Dtos.Users;

namespace PanaseWeb.Services.Interfaces
{
    public interface IAppointmentService : IModelService<AppointmentCreateDto, AppointmentResponseDto>
    {
        Task<bool> UpdateAsync(int id, AppointmentUpdateDto dto);
    }
}

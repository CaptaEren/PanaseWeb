using AutoMapper;
using PanaseWeb.Dtos.Appointments;
using PanaseWeb.Models;

namespace PanaseWeb.Profiles
{
    public class AppointmentProfiles : Profile
    {
        public AppointmentProfiles()
        {
            CreateMap<Appointment, AppointmentResponseDto>();
            CreateMap<AppointmentCreateDto, Appointment>();
            CreateMap<AppointmentUpdateDto, Appointment>();
        }
    }
}
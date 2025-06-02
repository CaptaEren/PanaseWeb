using AutoMapper;
using PanaseWeb.Dtos.TherapySessions;
using PanaseWeb.Models;

namespace PanaseWeb.Profiles
{
    public class TherapySessionProfiles : Profile
    {
        public TherapySessionProfiles()
        {
            CreateMap<TherapySession, TherapySessionResponseDto>();
            CreateMap<TherapySessionCreateDto, TherapySession>();
            CreateMap<TherapySessionResponseDto, TherapySession>();
        }
    }
}
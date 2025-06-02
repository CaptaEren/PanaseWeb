using AutoMapper;
using PanaseWeb.Dtos.Psychologists;
using PanaseWeb.Models;
using System.Linq;

namespace PanaseWeb.Profiles
{
    public class PsychologistProfiles : Profile
    {
        public PsychologistProfiles()
        {
            CreateMap<PsychologistCreateDto, Psychologist>();
            CreateMap<Psychologist, PsychologistResponseDto>();

            CreateMap<Psychologist, PsychologistDetailDto>()
                .ForMember(dest => dest.AvailabilitySlots,
                    opt => opt.MapFrom(src => src.Availabilities
                        .Select(a => $"{a.DayOfWeek} {a.StartTime:h\\:mm}-{a.EndTime:h\\:mm}")));
        }
    }
}
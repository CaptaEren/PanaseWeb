using AutoMapper;
using PanaseWeb.Dtos.Psychologists;
using PanaseWeb.Dtos.Users;
using PanaseWeb.Models;

namespace PanaseWeb.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            // Psychologist Mappings  
            CreateMap<PsychologistCreateDto, Psychologist>();
            CreateMap<Psychologist, PsychologistResponseDto>();
            CreateMap<Psychologist, PsychologistDetailDto>()
                .ForMember(dest => dest.AvailabilitySlots,
              opt => opt.MapFrom(src => src.Availabilities
                  .Select(a => $"{a.DayOfWeek} {a.StartTime:h\\:mm}-{a.EndTime:h\\:mm}")));

            // User Mappings  
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserProfileDto>();
            CreateMap<UserUpdateDto, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

using AutoMapper;
using PanaseWeb.Dtos.Users;
using PanaseWeb.Models;

namespace PanaseWeb.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserUpdateDto, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, UserResponseDto>();
            CreateMap<User, UserProfileDto>();
        }
    }
}
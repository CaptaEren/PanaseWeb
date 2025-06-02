using PanaseWeb.Dtos.Users;

namespace PanaseWeb.Services.Interfaces
{
    public interface IUserService : IModelService<UserRegisterDto, UserResponseDto>
    {
        Task<bool> UpdateAsync(int id, UserUpdateDto dto);
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PanaseWeb.Data;
using PanaseWeb.Dtos.Users;
using PanaseWeb.Models;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Services
{
    public class UserService : IUserService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public UserService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<UserResponseDto>>(await _context.Users.ToListAsync());

        public async Task<UserResponseDto?> GetByIdAsync(int id) =>
            _mapper.Map<UserResponseDto?>(await _context.Users.FindAsync(id));

        public async Task<UserResponseDto> CreateAsync(UserRegisterDto dto)
        {
            var entity = _mapper.Map<User>(dto);
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserResponseDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, UserUpdateDto dto)
        {
            var entity = await _context.Users.FindAsync(id);
            if (entity == null) return false;
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Users.FindAsync(id);
            if (entity == null) return false;
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

    }

}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PanaseWeb.Data;
using PanaseWeb.Dtos.TherapySessions;
using PanaseWeb.Models;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Services
{
    public class TherapySessionService : ITherapySessionService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public TherapySessionService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TherapySessionResponseDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<TherapySessionResponseDto>>(await _context.TherapySessions.ToListAsync());

        public async Task<TherapySessionResponseDto?> GetByIdAsync(int id) =>
            _mapper.Map<TherapySessionResponseDto?>(await _context.TherapySessions.FindAsync(id));

        public async Task<TherapySessionResponseDto> CreateAsync(TherapySessionCreateDto dto)
        {
            var entity = _mapper.Map<TherapySession>(dto);
            _context.TherapySessions.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TherapySessionResponseDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, TherapySessionResponseDto dto)
        {
            var entity = await _context.TherapySessions.FindAsync(id);
            if (entity == null) return false;
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.TherapySessions.FindAsync(id);
            if (entity == null) return false;
            _context.TherapySessions.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

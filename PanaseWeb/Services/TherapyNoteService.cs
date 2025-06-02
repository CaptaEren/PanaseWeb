using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PanaseWeb.Data;
using PanaseWeb.Dtos.TherapyNotes;
using PanaseWeb.Models;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Services
{
    public class TherapyNoteService : ITherapyNoteService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public TherapyNoteService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TherapyNoteResponseDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<TherapyNoteResponseDto>>(await _context.TherapyNotes.ToListAsync());

        public async Task<TherapyNoteResponseDto?> GetByIdAsync(int id) =>
            _mapper.Map<TherapyNoteResponseDto?>(await _context.TherapyNotes.FindAsync(id));

        public async Task<TherapyNoteResponseDto> CreateAsync(TherapyNoteCreateDto dto)
        {
            var entity = _mapper.Map<TherapyNote>(dto);
            _context.TherapyNotes.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TherapyNoteResponseDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, TherapyNoteCreateDto dto)
        {
            var entity = await _context.TherapyNotes.FindAsync(id);
            if (entity == null) return false;
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.TherapyNotes.FindAsync(id);
            if (entity == null) return false;
            _context.TherapyNotes.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

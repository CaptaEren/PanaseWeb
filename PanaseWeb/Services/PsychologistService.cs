using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PanaseWeb.Data;
using PanaseWeb.Dtos.Psychologists;
using PanaseWeb.Models;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Services
{
    public class PsychologistService : IPsychologistService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public PsychologistService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PsychologistResponseDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<PsychologistResponseDto>>(await _context.Psychologists.ToListAsync());

        public async Task<PsychologistResponseDto?> GetByIdAsync(int id) =>
            _mapper.Map<PsychologistResponseDto?>(await _context.Psychologists.FindAsync(id));

        public async Task<PsychologistDetailDto?> GetDetailByIdAsync(int id) =>
            _mapper.Map<PsychologistDetailDto?>(await _context.Psychologists.FindAsync(id));

        public async Task<PsychologistResponseDto> CreateAsync(PsychologistCreateDto dto)
        {
            var entity = _mapper.Map<Psychologist>(dto);
            _context.Psychologists.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PsychologistResponseDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, PsychologistUpdateDto dto)
        {
            var entity = await _context.Psychologists.FindAsync(id);
            if (entity == null) return false;
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Psychologists.FindAsync(id);
            if (entity == null) return false;
            _context.Psychologists.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

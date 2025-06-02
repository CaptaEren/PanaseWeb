using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PanaseWeb.Data;
using PanaseWeb.Dtos.PatientJournals;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Services
{
    public class PatientJournal : IPatientJournalService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public PatientJournal(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JournalEntryResponseDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<JournalEntryResponseDto>>(await _context.PatientJournals.ToListAsync());

        public async Task<JournalEntryResponseDto?> GetByIdAsync(int id) =>
            _mapper.Map<JournalEntryResponseDto>(await _context.PatientJournals.FindAsync(id));

        public async Task<JournalEntryResponseDto> CreateAsync(JournalEntryCreateDto dto)
        {
            var entity = _mapper.Map<PanaseWeb.Models.PatientJournal>(dto); // Correct type mapping
            _context.PatientJournals.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<JournalEntryResponseDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.PatientJournals.FindAsync(id);
            if (entity == null) return false;
            _context.PatientJournals.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

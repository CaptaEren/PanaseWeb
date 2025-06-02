using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PanaseWeb.Data;
using PanaseWeb.Dtos.Availabilities;
using PanaseWeb.Models;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Services
{
    public class AvailabityService : IAvailabilitiesService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public AvailabityService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AvailabilityResponseDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<AvailabilityResponseDto>>(await _context.Availabilities.ToListAsync());

        public async Task<AvailabilityResponseDto?> GetByIdAsync(int id) =>
            _mapper.Map<AvailabilityResponseDto?>(await _context.Availabilities.FindAsync(id));

        public async Task<AvailabilityResponseDto> CreateAsync(AvailabilityCreateDto dto)
        {
            var entity = _mapper.Map<Availability>(dto);
            _context.Availabilities.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<AvailabilityResponseDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Availabilities.FindAsync(id);
            if (entity == null) return false;
            _context.Availabilities.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

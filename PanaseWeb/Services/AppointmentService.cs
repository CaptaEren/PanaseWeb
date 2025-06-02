using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PanaseWeb.Data;
using PanaseWeb.Dtos.Appointments;
using PanaseWeb.Models;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public AppointmentService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppointmentResponseDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<AppointmentResponseDto>>(await _context.Appointments.ToListAsync());

        public async Task<AppointmentResponseDto?> GetByIdAsync(int id) =>
            _mapper.Map<AppointmentResponseDto?>(await _context.Appointments.FindAsync(id));

        public async Task<AppointmentResponseDto> CreateAsync(AppointmentCreateDto dto)
        {
            var entity = _mapper.Map<Appointment>(dto);
            _context.Appointments.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<AppointmentResponseDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, AppointmentUpdateDto dto)
        {
            var entity = await _context.Appointments.FindAsync(id);
            if (entity == null) return false;
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Appointments.FindAsync(id);
            if (entity == null) return false;
            _context.Appointments.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

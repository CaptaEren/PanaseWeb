using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PanaseWeb.Data;
using PanaseWeb.Dtos.Notifications;
using PanaseWeb.Models;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public NotificationService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<NotificationResponseDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<NotificationResponseDto>>(await _context.Notifications.ToListAsync());
        public async Task<NotificationResponseDto?> GetByIdAsync(int id) =>
            _mapper.Map<NotificationResponseDto?>(await _context.Notifications.FindAsync(id));
        public async Task<NotificationResponseDto> CreateAsync(NotificationCreateDto dto)
        {
            var entity = _mapper.Map<Notification>(dto);
            _context.Notifications.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<NotificationResponseDto>(entity);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Notifications.FindAsync(id);
            if (entity == null) return false;
            _context.Notifications.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

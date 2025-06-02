using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PanaseWeb.Data;
using PanaseWeb.Dtos.Payments;
using PanaseWeb.Models;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public PaymentService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentResponseDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PaymentResponseDto>>(await _context.Payments.ToListAsync());
        }

        public async Task<PaymentResponseDto?> GetByIdAsync(int id) =>
            _mapper.Map<PaymentResponseDto?>(await _context.Payments.FindAsync(id));

        public async Task<PaymentResponseDto> CreateAsync(PaymentCreateDto dto)
        {
            var entity = _mapper.Map<Payment>(dto);
            _context.Payments.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PaymentResponseDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, PaymentResponseDto dto)
        {
            var entity = await _context.Payments.FindAsync(id);
            if (entity == null) return false;
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Payments.FindAsync(id);
            if (entity == null) return false;
            _context.Payments.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

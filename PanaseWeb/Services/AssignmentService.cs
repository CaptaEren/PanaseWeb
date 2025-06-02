using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PanaseWeb.Data;
using PanaseWeb.Dtos.Assignments;
using PanaseWeb.Models;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public AssignmentService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AssignmentResponseDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<AssignmentResponseDto>>(await _context.Assignments.ToListAsync());

        public async Task<AssignmentResponseDto?> GetByIdAsync(int id) =>
            _mapper.Map<AssignmentResponseDto?>(await _context.Assignments.FindAsync(id));

        public async Task<AssignmentResponseDto> CreateAsync(AssignmentCreateDto dto)
        {
            var entity = _mapper.Map<Assignment>(dto);
            _context.Assignments.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<AssignmentResponseDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Assignments.FindAsync(id);
            if (entity == null) return false;
            _context.Assignments.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

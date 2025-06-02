using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PanaseWeb.Data;
using PanaseWeb.Dtos.Resources;
using PanaseWeb.Models;
using System.ComponentModel.Design;
using System.Globalization;
using System.Resources;

namespace PanaseWeb.Services
{
    public class ResourceService : IResourceService, Interfaces.IResourceService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ResourceService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResourceResponseDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<ResourceResponseDto>>(await _context.Resources.ToListAsync());

        public async Task<ResourceResponseDto?> GetByIdAsync(int id) =>
            _mapper.Map<ResourceResponseDto?>(await _context.Resources.FindAsync(id));

        public async Task<ResourceResponseDto> CreateAsync(ResourceCreateDto dto)
        {
            var entity = _mapper.Map<Resource>(dto);
            _context.Resources.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ResourceResponseDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Resources.FindAsync(id);
            if (entity == null) return false;
            _context.Resources.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public IResourceReader? GetResourceReader(CultureInfo info)
        {
            // Replace with actual resource file path or logic as needed
            return new ResourceReader("path_to_resource_file");
        }

        public IResourceWriter GetResourceWriter(CultureInfo info)
        {
            // Replace with actual resource file path or logic as needed
            return new ResourceWriter("path_to_resource_file");
        }
    }
}

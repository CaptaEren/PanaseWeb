using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PanaseWeb.Data;
using PanaseWeb.Dtos.BlogPosts;
using PanaseWeb.Models;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Services
{
    public class BlogService : IBlogService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public BlogService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BlogPostResponseDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<BlogPostResponseDto>>(await _context.BlogPosts.ToListAsync());

        public async Task<BlogPostResponseDto?> GetByIdAsync(int id) =>
            _mapper.Map<BlogPostResponseDto?>(await _context.BlogPosts.FindAsync(id));

        public async Task<BlogPostResponseDto> CreateAsync(BlogPostCreateDto dto)
        {
            var entity = _mapper.Map<BlogPost>(dto);
            _context.BlogPosts.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<BlogPostResponseDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, BlogPostResponseDto dto)
        {
            var entity = await _context.BlogPosts.FindAsync(id);
            if (entity == null) return false;
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.BlogPosts.FindAsync(id);
            if (entity == null) return false;
            _context.BlogPosts.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

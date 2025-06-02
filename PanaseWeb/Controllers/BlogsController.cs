using Microsoft.AspNetCore.Mvc;
using PanaseWeb.Dtos.BlogPosts;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        // GET: api/blogs
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var blogs = await _blogService.GetAllAsync();
            return Ok(blogs);
        }

        // GET: api/blogs/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null) return NotFound();
            return Ok(blog);
        }

        // POST: api/blogs
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] BlogPostCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _blogService.CreateAsync(dto);
            return Created($"/api/blogs/{created.Id}", created);
        }

        // PUT: api/blogs/{id}
        //[HttpPut("{id}")]
        /* 
        // PUT: api/blogs/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] BlogPostResponseDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _blogService.UpdateAsync(id, dto);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }
        */

        // DELETE: api/blogs/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _blogService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using PanaseWeb.Dtos.Psychologists;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PsychologistController : ControllerBase
    {
        private readonly IPsychologistService _service;

        public PsychologistController(IPsychologistService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var psychologists = await _service.GetAllAsync();
            return Ok(psychologists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var psychologist = await _service.GetByIdAsync(id);
            if (psychologist == null)
                return NotFound();
            return Ok(psychologist);
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetDetailById(int id)
        {
            var detail = await _service.GetDetailByIdAsync(id);
            if (detail == null)
                return NotFound();
            return Ok(detail);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PsychologistCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PsychologistUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}

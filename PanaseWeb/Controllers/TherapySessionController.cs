using Microsoft.AspNetCore.Mvc;
using PanaseWeb.Dtos.TherapySessions;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TherapySessionController : ControllerBase
    {
        private readonly ITherapySessionService _service;

        public TherapySessionController(ITherapySessionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sessions = await _service.GetAllAsync();
            return Ok(sessions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var session = await _service.GetByIdAsync(id);
            if (session == null) return NotFound();
            return Ok(session);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TherapySessionCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        ////[HttpPut("{id}")]
        ////public async Task<IActionResult> Update(int id, [FromBody] TherapySessionResponseDto dto)
        ////{
        ////    if (!ModelState.IsValid)
        ////        return BadRequest(ModelState);

        ////    var updated = await _service.UpdateAsync(id, dto);
        ////    if (!updated) return NotFound();

        ////    return NoContent();
        ////}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
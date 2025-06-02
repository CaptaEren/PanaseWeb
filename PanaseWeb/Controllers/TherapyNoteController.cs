using Microsoft.AspNetCore.Mvc;
using PanaseWeb.Dtos.TherapyNotes;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TherapyNoteController : ControllerBase
    {
        private readonly ITherapyNoteService _service;

        public TherapyNoteController(ITherapyNoteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notes = await _service.GetAllAsync();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var note = await _service.GetByIdAsync(id);
            if (note == null) return NotFound();
            return Ok(note);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TherapyNoteCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdNote = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdNote.Id }, createdNote);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody] TherapyNoteCreateDto dto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var updated = await _service.UpdateAsync(id, dto);
        //    if (!updated) return NotFound();

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
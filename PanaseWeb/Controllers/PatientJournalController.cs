using Microsoft.AspNetCore.Mvc;
using PanaseWeb.Dtos.PatientJournals;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientJournalController : ControllerBase
    {
        private readonly IPatientJournalService _service;

        public PatientJournalController(IPatientJournalService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var journals = await _service.GetAllAsync();
            return Ok(journals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var journal = await _service.GetByIdAsync(id);
            if (journal == null)
                return NotFound();
            return Ok(journal);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JournalEntryCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using PanaseWeb.Dtos.Assignments;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentsController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        // GET: api/assignments
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var assignments = await _assignmentService.GetAllAsync();
            return Ok(assignments);
        }

        // GET: api/assignments/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var assignment = await _assignmentService.GetByIdAsync(id);
            if (assignment == null) return NotFound();
            return Ok(assignment);
        }

        // POST: api/assignments
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AssignmentCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _assignmentService.CreateAsync(dto);
            return Created($"/api/assignments/{created.Id}", created);
        }

        // DELETE: api/assignments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _assignmentService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
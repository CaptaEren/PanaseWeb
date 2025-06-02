using Microsoft.AspNetCore.Mvc;
using PanaseWeb.Dtos.Availabilities;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvailabilitiesController : ControllerBase
    {
        private readonly IAvailabilitiesService _availabilityService;

        public AvailabilitiesController(IAvailabilitiesService availabilityService)
        {
            _availabilityService = availabilityService;
        }

        // GET: api/availabilities
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var availabilities = await _availabilityService.GetAllAsync();
            return Ok(availabilities);
        }

        // GET: api/availabilities/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var availability = await _availabilityService.GetByIdAsync(id);
            if (availability == null) return NotFound();
            return Ok(availability);
        }

        // POST: api/availabilities
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AvailabilityCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _availabilityService.CreateAsync(dto);
            return Created($"/api/availabilities/{created.Id}", created);
        }

        // DELETE: api/availabilities/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _availabilityService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
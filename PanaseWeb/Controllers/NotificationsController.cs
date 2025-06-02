using Microsoft.AspNetCore.Mvc;
using PanaseWeb.Dtos.Notifications;
using PanaseWeb.Services.Interfaces;

namespace PanaseWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GET: api/notifications
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var notifications = await _notificationService.GetAllAsync();
            return Ok(notifications);
        }

        // GET: api/notifications/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var notification = await _notificationService.GetByIdAsync(id);
            if (notification == null) return NotFound();
            return Ok(notification);
        }

        // POST: api/notifications
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] NotificationCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _notificationService.CreateAsync(dto);
            return Created($"/api/notifications/{created.Id}", created);
        }

        // DELETE: api/notifications/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _notificationService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
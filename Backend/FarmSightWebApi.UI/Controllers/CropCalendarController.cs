using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.CropCalendar;
using FarmSightWebApi.ApplicationCore.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FarmSightWebApi.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CropCalendarController : ControllerBase
    {
        private readonly ICropCalendarService _cropCalendarService;

        public CropCalendarController(ICropCalendarService cropCalendarService)
        {
            _cropCalendarService = cropCalendarService;
        }

        // POST: api/cropcalendar
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCropCalendarRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var calendar = await _cropCalendarService.CreateCalendarAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = calendar.Id }, calendar);
        }

        // PUT: api/cropcalendar/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCropCalendarRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _cropCalendarService.UpdateCalendarAsync(id, request);
            return updated == null ? NotFound() : Ok(updated);
        }

        // GET: api/cropcalendar
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var calendars = await _cropCalendarService.GetAllAsync();
            return Ok(calendars);
        }

        // GET: api/cropcalendar/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var calendar = await _cropCalendarService.GetByIdAsync(id);
            return calendar == null ? NotFound() : Ok(calendar);
        }

        // GET: api/cropcalendar/field/{fieldId}
        [HttpGet("field/{fieldId:guid}")]
        public async Task<IActionResult> GetByFieldId(Guid fieldId)
        {
            var calendar = await _cropCalendarService.GetByFieldIdAsync(fieldId);
            return calendar == null ? NotFound() : Ok(calendar);
        }

        // DELETE: api/cropcalendar/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _cropCalendarService.DeleteCalendarAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}

using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.Alert;
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
    public class AlertController : ControllerBase
    {
        private readonly IAlertService _alertService;

        public AlertController(IAlertService alertService)
        {
            _alertService = alertService;
        }

        // POST: api/alert
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAlertRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var alert = await _alertService.CreateAlertAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = alert.Id }, alert);
        }

        // PUT: api/alert/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAlertRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _alertService.UpdateAlertAsync(id, request);
            return updated == null ? NotFound() : Ok(updated);
        }

        // GET: api/alert
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alerts = await _alertService.GetAllAsync();
            return Ok(alerts);
        }

        // GET: api/alert/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var alert = await _alertService.GetByIdAsync(id);
            return alert == null ? NotFound() : Ok(alert);
        }

        // GET: api/alert/field/{fieldId}
        [HttpGet("field/{fieldId:guid}")]
        public async Task<IActionResult> GetByFieldId(Guid fieldId)
        {
            var alerts = await _alertService.GetByFieldIdAsync(fieldId);
            return Ok(alerts);
        }

        // DELETE: api/alert/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _alertService.DeleteAlertAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}

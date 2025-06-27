using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.MessageLog;
using FarmSightWebApi.ApplicationCore.DTO.MessageLogye;
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
    public class MessageLogController : ControllerBase
    {
        private readonly IMessageLogService _messageLogService;

        public MessageLogController(IMessageLogService messageLogService)
        {
            _messageLogService = messageLogService;
        }

        // POST: api/messagelog
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMessageLogRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var log = await _messageLogService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = log.Id }, log);
        }

        // PUT: api/messagelog/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMessageLogRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _messageLogService.UpdateAsync(id, request);
            return updated == null ? NotFound() : Ok(updated);
        }

        // GET: api/messagelog
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var logs = await _messageLogService.GetAllAsync();
            return Ok(logs);
        }

        // GET: api/messagelog/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var log = await _messageLogService.GetByIdAsync(id);
            return log == null ? NotFound() : Ok(log);
        }

        // GET: api/messagelog/farmer/{farmerId}
        [HttpGet("farmer/{farmerId:guid}")]
        public async Task<IActionResult> GetByFarmerId(Guid farmerId)
        {
            var logs = await _messageLogService.GetByFarmerIdAsync(farmerId);
            return Ok(logs);
        }

        // GET: api/messagelog/field/{fieldId}
        [HttpGet("field/{fieldId:guid}")]
        public async Task<IActionResult> GetByFieldId(Guid fieldId)
        {
            var logs = await _messageLogService.GetByFieldIdAsync(fieldId);
            return Ok(logs);
        }

        // DELETE: api/messagelog/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _messageLogService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}

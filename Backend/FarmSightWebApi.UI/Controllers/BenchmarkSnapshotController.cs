using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.BenchmarkSnapshot;
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
    public class BenchmarkSnapshotController : ControllerBase
    {
        private readonly IBenchmarkSnapshotService _service;

        public BenchmarkSnapshotController(IBenchmarkSnapshotService service)
        {
            _service = service;
        }

        // POST: api/benchmarksnapshot
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBenchmarkSnapshotRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/benchmarksnapshot/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBenchmarkSnapshotRequest request)
        {
            var updated = await _service.UpdateAsync(id, request);
            return updated == null ? NotFound() : Ok(updated);
        }

        // GET: api/benchmarksnapshot
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        // GET: api/benchmarksnapshot/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var snapshot = await _service.GetByIdAsync(id);
            return snapshot == null ? NotFound() : Ok(snapshot);
        }

        // GET: api/benchmarksnapshot/field/{fieldId}
        [HttpGet("field/{fieldId:guid}")]
        public async Task<IActionResult> GetByField(Guid fieldId)
        {
            var data = await _service.GetByFieldIdAsync(fieldId);
            return Ok(data);
        }

        // GET: api/benchmarksnapshot/field/{fieldId}/date?date=2024-09-01
        [HttpGet("field/{fieldId:guid}/date")]
        public async Task<IActionResult> GetByFieldAndDate(Guid fieldId, [FromQuery] DateTime date)
        {
            var data = await _service.GetByFieldAndDateAsync(fieldId, date);
            return data == null ? NotFound() : Ok(data);
        }

        // DELETE: api/benchmarksnapshot/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}

using FarmSightWebApi.ApplicationCore.DTO.Field;
using FarmSightWebApi.ApplicationCore.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FarmSightWebApi.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FieldController : ControllerBase
    {
        private readonly IFieldService _fieldService;

        public FieldController(IFieldService fieldService)
        {
            _fieldService = fieldService;
        }

        // GET: api/field/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetFieldById(Guid id)
        {
            var field = await _fieldService.GetFieldByIdAsync(id);
            return field == null ? NotFound() : Ok(field);
        }

        // GET: api/field/farmer/{farmerId}
        [HttpGet("farmer/{farmerId:guid}")]
        public async Task<IActionResult> GetFieldsByFarmer(Guid farmerId)
        {
            var fields = await _fieldService.GetFieldsByFarmerAsync(farmerId);
            return Ok(fields);
        }

        // GET: api/field
        [HttpGet]
        public async Task<IActionResult> GetAllFields()
        {
            var fields = await _fieldService.GetAllFieldsAsync();
            return Ok(fields);
        }

        // POST: api/field/{farmerId}
        [HttpPost("{farmerId:guid}")]
        public async Task<IActionResult> CreateField(Guid farmerId, [FromBody] CreateFieldRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var field = await _fieldService.CreateFieldAsync(request, farmerId);
            return CreatedAtAction(nameof(GetFieldById), new { id = field.Id }, field);
        }

        // PUT: api/field/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateField(Guid id, [FromBody] UpdateFieldRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _fieldService.UpdateFieldAsync(id, request);
            return updated == null ? NotFound() : Ok(updated);
        }

        // DELETE: api/field/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteField(Guid id)
        {
            var result = await _fieldService.DeleteFieldAsync(id);
            return result ? NoContent() : NotFound();
        }

        // GET: api/field/centroid?lat=12.3&lng=7.8
        [HttpGet("centroid")]
        public async Task<IActionResult> GetByCentroid([FromQuery] double lat, [FromQuery] double lng)
        {
            var field = await _fieldService.GetFieldByCentroidAsync(lat, lng);
            return field == null ? NotFound() : Ok(field);
        }

        // GET: api/field/nearby?lat=12.3&lng=7.8&radiusKm=5
        [HttpGet("nearby")]
        public async Task<IActionResult> GetWithinRadius([FromQuery] double lat, [FromQuery] double lng, [FromQuery] double radiusKm)
        {
            var fields = await _fieldService.GetFieldsWithinRadiusAsync(lat, lng, radiusKm);
            return Ok(fields);
        }
    }
}

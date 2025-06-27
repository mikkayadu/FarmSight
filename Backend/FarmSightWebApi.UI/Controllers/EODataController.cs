using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.EOData;
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
    public class EODataController : ControllerBase
    {
        private readonly IEODataService _eoDataService;

        public EODataController(IEODataService eoDataService)
        {
            _eoDataService = eoDataService;
        }

        // POST: api/eodata
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEODataRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _eoDataService.CreateEODataAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // GET: api/eodata
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _eoDataService.GetAllAsync();
            return Ok(data);
        }

        // GET: api/eodata/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await _eoDataService.GetByIdAsync(id);
            return data == null ? NotFound() : Ok(data);
        }

        // GET: api/eodata/field/{fieldId}
        [HttpGet("field/{fieldId:guid}")]
        public async Task<IActionResult> GetByFieldId(Guid fieldId)
        {
            var data = await _eoDataService.GetByFieldIdAsync(fieldId);
            return Ok(data);
        }

        // PUT: api/eodata/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEODataRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _eoDataService.UpdateEODataAsync(id, request);
            return updated == null ? NotFound() : Ok(updated);
        }

        // DELETE: api/eodata/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _eoDataService.DeleteEODataAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}

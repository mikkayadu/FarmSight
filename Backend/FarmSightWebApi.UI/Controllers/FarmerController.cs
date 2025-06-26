using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.Farmer;
using FarmSightWebApi.ApplicationCore.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FarmSightWebApi.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FarmerController : ControllerBase
    {
        private readonly IFarmerService _farmerService;

        public FarmerController(IFarmerService farmerService)
        {
            _farmerService = farmerService;
        }

        // GET: api/farmer/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetFarmerById(Guid id)
        {
            var farmer = await _farmerService.GetFarmerByIdAsync(id);
            return farmer == null ? NotFound() : Ok(farmer);
        }

        // GET: api/farmer
        [HttpGet]
        public async Task<IActionResult> GetAllFarmers()
        {
            var farmers = await _farmerService.GetAllFarmersAsync();
            return Ok(farmers);
        }

        // POST: api/farmer
        [HttpPost]
        public async Task<IActionResult> CreateFarmer([FromBody] CreateFarmerRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var farmer = await _farmerService.CreateFarmerAsync(request);
            return CreatedAtAction(nameof(GetFarmerById), new { id = farmer.Id }, farmer);
        }

        // PUT: api/farmer/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateFarmer(Guid id, [FromBody] UpdateFarmerRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _farmerService.UpdateFarmerAsync(id, request);
            return updated == null ? NotFound() : Ok(updated);
        }

        // DELETE: api/farmer/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteFarmer(Guid id)
        {
            var result = await _farmerService.DeleteFarmerAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}

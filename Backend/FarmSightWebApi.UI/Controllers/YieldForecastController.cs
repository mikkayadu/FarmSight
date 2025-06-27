using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.YieldForecast;
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
    public class YieldForecastController : ControllerBase
    {
        private readonly IYieldForecastService _forecastService;

        public YieldForecastController(IYieldForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        // POST: api/yieldforecast
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateYieldForecastRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var forecast = await _forecastService.CreateForecastAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = forecast.Id }, forecast);
        }

        // PUT: api/yieldforecast/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateYieldForecastRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _forecastService.UpdateForecastAsync(id, request);
            return updated == null ? NotFound() : Ok(updated);
        }

        // GET: api/yieldforecast
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var forecasts = await _forecastService.GetAllAsync();
            return Ok(forecasts);
        }

        // GET: api/yieldforecast/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var forecast = await _forecastService.GetByIdAsync(id);
            return forecast == null ? NotFound() : Ok(forecast);
        }

        // GET: api/yieldforecast/field/{fieldId}
        [HttpGet("field/{fieldId:guid}")]
        public async Task<IActionResult> GetByFieldId(Guid fieldId)
        {
            var forecasts = await _forecastService.GetByFieldIdAsync(fieldId);
            return Ok(forecasts);
        }

        // DELETE: api/yieldforecast/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _forecastService.DeleteForecastAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}

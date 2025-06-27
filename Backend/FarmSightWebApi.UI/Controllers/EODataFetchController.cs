using FarmSightWebApi.ApplicationCore.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FarmSightWebApi.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EODataFetchController : ControllerBase
    {
        private readonly IEODataFetchService _eoDataFetchService;

        public EODataFetchController(IEODataFetchService eoDataFetchService)
        {
            _eoDataFetchService = eoDataFetchService;
        }

        // Manually fetch EO data for ALL fields on a given date
        [HttpPost("fetch-all")]
        public async Task<IActionResult> FetchAll([FromQuery] DateTime? date)
        {
            var fetchDate = date ?? DateTime.UtcNow.Date;
            var count = await _eoDataFetchService.FetchForAllFieldsAsync(fetchDate);
            return Ok(new { ProcessedFields = count, Date = fetchDate });
        }

        // Manually fetch EO data for ONE field
        [HttpPost("fetch-one/{fieldId}")]
        public async Task<IActionResult> FetchOne(Guid fieldId, [FromQuery] DateTime? date)
        {
            var fetchDate = date ?? DateTime.UtcNow.Date;
            var success = await _eoDataFetchService.FetchAndSaveEODataForFieldAsync(fieldId, fetchDate);
            return Ok(new { FieldId = fieldId, Success = success });
        }
    }
}

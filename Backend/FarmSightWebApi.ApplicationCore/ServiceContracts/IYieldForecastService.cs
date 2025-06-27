using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.YieldForecast;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.ServiceContracts
{
    public interface IYieldForecastService
    {
        Task<YieldForecastResponse> CreateForecastAsync(CreateYieldForecastRequest request);
        Task<YieldForecastResponse> UpdateForecastAsync(Guid id, UpdateYieldForecastRequest request);
        Task<bool> DeleteForecastAsync(Guid id);
        Task<YieldForecastResponse> GetByIdAsync(Guid id);
        Task<IEnumerable<YieldForecastResponse>> GetByFieldIdAsync(Guid fieldId);
        Task<IEnumerable<YieldForecastResponse>> GetAllAsync();
    }
}

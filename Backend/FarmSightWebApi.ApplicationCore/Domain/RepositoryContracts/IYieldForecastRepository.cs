using FarmSightWebApi.ApplicationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts
{
    public interface IYieldForecastRepository
    {
        Task<YieldForecast> AddAsync(YieldForecast forecast);
        Task<YieldForecast> GetByIdAsync(Guid id);
        Task<IEnumerable<YieldForecast>> GetByFieldIdAsync(Guid fieldId);
        Task<IEnumerable<YieldForecast>> GetAllAsync();
        Task UpdateAsync(YieldForecast forecast);
        Task DeleteAsync(YieldForecast forecast);
    }
}

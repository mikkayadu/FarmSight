using FarmSightWebApi.ApplicationCore.Domain.Entities;
using FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts;
using FarmSightWebApi.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmSightWebApi.Infrastructure.Repositories
{
    public class YieldForecastRepository : IYieldForecastRepository
    {
        private readonly FarmSightDbContext _context;

        public YieldForecastRepository(FarmSightDbContext context)
        {
            _context = context;
        }

        public async Task<YieldForecast> AddAsync(YieldForecast forecast)
        {
            await _context.YieldForecasts.AddAsync(forecast);
            await _context.SaveChangesAsync();
            return forecast;
        }

        public async Task DeleteAsync(YieldForecast forecast)
        {
            _context.YieldForecasts.Remove(forecast);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<YieldForecast>> GetAllAsync()
        {
            return await _context.YieldForecasts.ToListAsync();
        }

        public async Task<YieldForecast> GetByIdAsync(Guid id)
        {
            return await _context.YieldForecasts.FindAsync(id);
        }

        public async Task<IEnumerable<YieldForecast>> GetByFieldIdAsync(Guid fieldId)
        {
            return await _context.YieldForecasts
                .Where(f => f.FieldId == fieldId)
                .OrderByDescending(f => f.ForecastDate)
                .ToListAsync();
        }

        public async Task UpdateAsync(YieldForecast forecast)
        {
            _context.YieldForecasts.Update(forecast);
            await _context.SaveChangesAsync();
        }
    }
}

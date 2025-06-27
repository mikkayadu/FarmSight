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
    public class AlertRepository : IAlertRepository
    {
        private readonly FarmSightDbContext _context;

        public AlertRepository(FarmSightDbContext context)
        {
            _context = context;
        }

        public async Task<Alert> AddAsync(Alert alert)
        {
            await _context.Alerts.AddAsync(alert);
            await _context.SaveChangesAsync();
            return alert;
        }

        public async Task DeleteAsync(Alert alert)
        {
            _context.Alerts.Remove(alert);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Alert>> GetAllAsync()
        {
            return await _context.Alerts.ToListAsync();
        }

        public async Task<Alert> GetByIdAsync(Guid id)
        {
            return await _context.Alerts.FindAsync(id);
        }

        public async Task<IEnumerable<Alert>> GetByFieldIdAsync(Guid fieldId)
        {
            return await _context.Alerts
                .Where(a => a.FieldId == fieldId)
                .OrderByDescending(a => a.SentAt)
                .ToListAsync();
        }

        public async Task UpdateAsync(Alert alert)
        {
            _context.Alerts.Update(alert);
            await _context.SaveChangesAsync();
        }
    }
}

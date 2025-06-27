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
    public class CropCalendarRepository : ICropCalendarRepository
    {
        private readonly FarmSightDbContext _context;

        public CropCalendarRepository(FarmSightDbContext context)
        {
            _context = context;
        }

        public async Task<CropCalendar> AddAsync(CropCalendar calendar)
        {
            await _context.CropCalendars.AddAsync(calendar);
            await _context.SaveChangesAsync();
            return calendar;
        }

        public async Task DeleteAsync(CropCalendar calendar)
        {
            _context.CropCalendars.Remove(calendar);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CropCalendar>> GetAllAsync()
        {
            return await _context.CropCalendars.ToListAsync();
        }

        public async Task<CropCalendar> GetByIdAsync(Guid id)
        {
            return await _context.CropCalendars.FindAsync(id);
        }

        public async Task<CropCalendar> GetByFieldIdAsync(Guid fieldId)
        {
            return await _context.CropCalendars
                .FirstOrDefaultAsync(c => c.FieldId == fieldId);
        }

        public async Task UpdateAsync(CropCalendar calendar)
        {
            _context.CropCalendars.Update(calendar);
            await _context.SaveChangesAsync();
        }
    }
}

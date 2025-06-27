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
    public class EODataRepository : IEODataRepository
    {
        private readonly FarmSightDbContext _context;

        public EODataRepository(FarmSightDbContext context)
        {
            _context = context;
        }

        public async Task<EOData> AddAsync(EOData data)
        {
            await _context.EOData.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task DeleteAsync(EOData data)
        {
            _context.EOData.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EOData>> GetAllAsync()
        {
            return await _context.EOData.ToListAsync();
        }

        public async Task<EOData> GetByIdAsync(Guid id)
        {
            return await _context.EOData.FindAsync(id);
        }

        public async Task<IEnumerable<EOData>> GetByFieldIdAsync(Guid fieldId)
        {
            return await _context.EOData
                .Where(e => e.FieldId == fieldId)
                .OrderByDescending(e => e.Timestamp)
                .ToListAsync();
        }

        public async Task UpdateAsync(EOData data)
        {
            _context.EOData.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}

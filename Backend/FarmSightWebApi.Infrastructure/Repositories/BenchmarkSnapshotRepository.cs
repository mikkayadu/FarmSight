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
    public class BenchmarkSnapshotRepository : IBenchmarkSnapshotRepository
    {
        private readonly FarmSightDbContext _context;

        public BenchmarkSnapshotRepository(FarmSightDbContext context)
        {
            _context = context;
        }

        public async Task<BenchmarkSnapshot> AddAsync(BenchmarkSnapshot snapshot)
        {
            await _context.BenchmarkSnapshots.AddAsync(snapshot);
            await _context.SaveChangesAsync();
            return snapshot;
        }

        public async Task DeleteAsync(BenchmarkSnapshot snapshot)
        {
            _context.BenchmarkSnapshots.Remove(snapshot);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BenchmarkSnapshot>> GetAllAsync()
        {
            return await _context.BenchmarkSnapshots.ToListAsync();
        }

        public async Task<BenchmarkSnapshot> GetByIdAsync(Guid id)
        {
            return await _context.BenchmarkSnapshots.FindAsync(id);
        }

        public async Task<IEnumerable<BenchmarkSnapshot>> GetByFieldIdAsync(Guid fieldId)
        {
            return await _context.BenchmarkSnapshots
                .Where(s => s.FieldId == fieldId)
                .OrderByDescending(s => s.SnapshotDate)
                .ToListAsync();
        }

        public async Task<BenchmarkSnapshot> GetByFieldAndDateAsync(Guid fieldId, DateTime date)
        {
            return await _context.BenchmarkSnapshots
                .FirstOrDefaultAsync(s => s.FieldId == fieldId && s.SnapshotDate.Date == date.Date);
        }

        public async Task UpdateAsync(BenchmarkSnapshot snapshot)
        {
            _context.BenchmarkSnapshots.Update(snapshot);
            await _context.SaveChangesAsync();
        }
    }
}

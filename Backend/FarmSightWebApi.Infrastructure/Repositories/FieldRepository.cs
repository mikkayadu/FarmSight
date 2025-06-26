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
    public class FieldRepository : IFieldRepository
    {
        private readonly FarmSightDbContext _context;

        public FieldRepository(FarmSightDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Field field)
        {
            await _context.Fields.AddAsync(field);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Field field)
        {
            _context.Fields.Remove(field);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Field>> GetAllAsync()
        {
            return await _context.Fields.ToListAsync();
        }

        public async Task<Field> GetByIdAsync(Guid id)
        {
            return await _context.Fields.FindAsync(id);
        }

        public async Task<IEnumerable<Field>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Fields
                .Where(f => f.FarmerId == userId)
                .ToListAsync();
        }

        public async Task UpdateAsync(Field field)
        {
            _context.Fields.Update(field);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid fieldId)
        {
            return await _context.Fields.AnyAsync(f => f.Id == fieldId);
        }

        public async Task<IEnumerable<Field>> GetWithinBoundingBoxAsync(double lat, double lng, double radiusKm)
        {
            // Approximation using lat/lng range (not accurate for large areas)
            const double degreePerKm = 0.009; // ~1km in degrees
            double delta = radiusKm * degreePerKm;

            return await _context.Fields
                .Where(f =>
                    f.CenterLat >= lat - delta &&
                    f.CenterLat <= lat + delta &&
                    f.CenterLng >= lng - delta &&
                    f.CenterLng <= lng + delta)
                .ToListAsync();
        }

        public async Task<Field?> GetByCentroidAsync(double lat, double lng)
        {
            return await _context.Fields
                .FirstOrDefaultAsync(f =>
                    Math.Abs(f.CenterLat - lat) < 0.00001 &&
                    Math.Abs(f.CenterLng - lng) < 0.00001);
        }

    }
}

using FarmSightWebApi.ApplicationCore.Domain.Entities;
using FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts;
using FarmSightWebApi.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmSightWebApi.Infrastructure.Repositories
{
    public class FarmerRepository : IFarmerRepository
    {
        private readonly FarmSightDbContext _context;

        public FarmerRepository(FarmSightDbContext context)
        {
            _context = context;
        }

        public async Task<Farmer> GetByIdAsync(Guid id)
        {
            return await _context.Farmers.FindAsync(id);
        }

        public async Task<IEnumerable<Farmer>> GetAllAsync()
        {
            return await _context.Farmers.ToListAsync();
        }

        public async Task AddAsync(Farmer farmer)
        {
            await _context.Farmers.AddAsync(farmer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Farmer farmer)
        {
            _context.Farmers.Update(farmer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Farmer farmer)
        {
            _context.Farmers.Remove(farmer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Farmers.AnyAsync(f => f.Id == id);
        }
    }
}

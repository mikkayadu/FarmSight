using FarmSightWebApi.ApplicationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts
{
    public interface IFarmerRepository
    {
        Task<Farmer> GetByIdAsync(Guid id);
        Task<IEnumerable<Farmer>> GetAllAsync();
        Task AddAsync(Farmer farmer);
        Task UpdateAsync(Farmer farmer);
        Task DeleteAsync(Farmer farmer);
        Task<bool> ExistsAsync(Guid id);
    }
}

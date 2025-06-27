using FarmSightWebApi.ApplicationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts
{
    public interface IEODataRepository
    {
        Task<EOData> AddAsync(EOData data);
        Task<EOData> GetByIdAsync(Guid id);
        Task<IEnumerable<EOData>> GetByFieldIdAsync(Guid fieldId);
        Task<IEnumerable<EOData>> GetAllAsync();
        Task UpdateAsync(EOData data);
        Task DeleteAsync(EOData data);
    }
}

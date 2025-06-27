using FarmSightWebApi.ApplicationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts
{
    public interface IBenchmarkSnapshotRepository
    {
        Task<BenchmarkSnapshot> AddAsync(BenchmarkSnapshot snapshot);
        Task UpdateAsync(BenchmarkSnapshot snapshot);
        Task DeleteAsync(BenchmarkSnapshot snapshot);

        Task<BenchmarkSnapshot> GetByIdAsync(Guid id);
        Task<IEnumerable<BenchmarkSnapshot>> GetAllAsync();
        Task<IEnumerable<BenchmarkSnapshot>> GetByFieldIdAsync(Guid fieldId);
        Task<BenchmarkSnapshot> GetByFieldAndDateAsync(Guid fieldId, DateTime date);
    }
}

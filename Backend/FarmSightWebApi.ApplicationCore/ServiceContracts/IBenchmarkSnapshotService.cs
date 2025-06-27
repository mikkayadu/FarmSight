using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.BenchmarkSnapshot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.ServiceContracts
{
    public interface IBenchmarkSnapshotService
    {
        Task<BenchmarkSnapshotResponse> CreateAsync(CreateBenchmarkSnapshotRequest request);
        Task<BenchmarkSnapshotResponse> UpdateAsync(Guid id, UpdateBenchmarkSnapshotRequest request);
        Task<bool> DeleteAsync(Guid id);

        Task<BenchmarkSnapshotResponse> GetByIdAsync(Guid id);
        Task<IEnumerable<BenchmarkSnapshotResponse>> GetAllAsync();
        Task<IEnumerable<BenchmarkSnapshotResponse>> GetByFieldIdAsync(Guid fieldId);
        Task<BenchmarkSnapshotResponse> GetByFieldAndDateAsync(Guid fieldId, DateTime date);
    }
}

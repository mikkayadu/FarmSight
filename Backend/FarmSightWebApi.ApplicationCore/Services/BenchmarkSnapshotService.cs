using FarmSightWebApi.ApplicationCore.Domain.Entities;
using FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts;
using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.BenchmarkSnapshot;
using FarmSightWebApi.ApplicationCore.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Services
{
    public class BenchmarkSnapshotService : IBenchmarkSnapshotService
    {
        private readonly IBenchmarkSnapshotRepository _repository;

        public BenchmarkSnapshotService(IBenchmarkSnapshotRepository repository)
        {
            _repository = repository;
        }

        public async Task<BenchmarkSnapshotResponse> CreateAsync(CreateBenchmarkSnapshotRequest request)
        {
            var snapshot = new BenchmarkSnapshot
            {
                Id = Guid.NewGuid(),
                FieldId = request.FieldId,
                SnapshotDate = request.SnapshotDate,
                AvgNDVI = request.AvgNDVI,
                AvgMoisture = request.AvgMoisture,
                FieldCount = request.FieldCount
            };

            await _repository.AddAsync(snapshot);
            return MapToResponse(snapshot);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var snapshot = await _repository.GetByIdAsync(id);
            if (snapshot == null) return false;

            await _repository.DeleteAsync(snapshot);
            return true;
        }

        public async Task<IEnumerable<BenchmarkSnapshotResponse>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return data.Select(MapToResponse);
        }

        public async Task<BenchmarkSnapshotResponse> GetByIdAsync(Guid id)
        {
            var snapshot = await _repository.GetByIdAsync(id);
            return snapshot == null ? null : MapToResponse(snapshot);
        }

        public async Task<IEnumerable<BenchmarkSnapshotResponse>> GetByFieldIdAsync(Guid fieldId)
        {
            var data = await _repository.GetByFieldIdAsync(fieldId);
            return data.Select(MapToResponse);
        }

        public async Task<BenchmarkSnapshotResponse> GetByFieldAndDateAsync(Guid fieldId, DateTime date)
        {
            var snapshot = await _repository.GetByFieldAndDateAsync(fieldId, date);
            return snapshot == null ? null : MapToResponse(snapshot);
        }

        public async Task<BenchmarkSnapshotResponse> UpdateAsync(Guid id, UpdateBenchmarkSnapshotRequest request)
        {
            var snapshot = await _repository.GetByIdAsync(id);
            if (snapshot == null) return null;

            if (request.AvgNDVI.HasValue) snapshot.AvgNDVI = request.AvgNDVI.Value;
            if (request.AvgMoisture.HasValue) snapshot.AvgMoisture = request.AvgMoisture.Value;
            if (request.FieldCount.HasValue) snapshot.FieldCount = request.FieldCount.Value;

            await _repository.UpdateAsync(snapshot);
            return MapToResponse(snapshot);
        }

        private BenchmarkSnapshotResponse MapToResponse(BenchmarkSnapshot s) => new BenchmarkSnapshotResponse
        {
            Id = s.Id,
            FieldId = s.FieldId,
            SnapshotDate = s.SnapshotDate,
            AvgNDVI = s.AvgNDVI,
            AvgMoisture = s.AvgMoisture,
            FieldCount = s.FieldCount
        };
    }
}

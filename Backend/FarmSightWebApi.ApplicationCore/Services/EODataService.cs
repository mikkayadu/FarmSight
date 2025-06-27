using FarmSightWebApi.ApplicationCore.Domain.Entities;
using FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts;
using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.EOData;
using FarmSightWebApi.ApplicationCore.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Services
{
    public class EODataService : IEODataService
    {
        private readonly IEODataRepository _repository;

        public EODataService(IEODataRepository repository)
        {
            _repository = repository;
        }

        public async Task<EODataResponse> CreateEODataAsync(CreateEODataRequest request)
        {
            var entity = new EOData
            {
                Id = Guid.NewGuid(),
                FieldId = request.FieldId,
                Timestamp = request.Timestamp,
                NDVI = request.NDVI,
                SoilMoisture = request.SoilMoisture,
                Rainfall = request.Rainfall,
                Temperature = request.Temperature,
                DroughtIndex = request.DroughtIndex,
                FloodRisk = request.FloodRisk
            };

            await _repository.AddAsync(entity);
            return MapToResponse(entity);
        }

        public async Task<bool> DeleteEODataAsync(Guid id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            await _repository.DeleteAsync(existing);
            return true;
        }

        public async Task<IEnumerable<EODataResponse>> GetAllAsync()
        {
            var all = await _repository.GetAllAsync();
            return all.Select(MapToResponse);
        }

        public async Task<EODataResponse> GetByIdAsync(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item == null ? null : MapToResponse(item);
        }

        public async Task<IEnumerable<EODataResponse>> GetByFieldIdAsync(Guid fieldId)
        {
            var list = await _repository.GetByFieldIdAsync(fieldId);
            return list.Select(MapToResponse);
        }

        public async Task<EODataResponse> UpdateEODataAsync(Guid id, UpdateEODataRequest request)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return null;

            item.Timestamp = request.Timestamp;
            item.NDVI = request.NDVI;
            item.SoilMoisture = request.SoilMoisture;
            item.Rainfall = request.Rainfall;
            item.Temperature = request.Temperature;
            item.DroughtIndex = request.DroughtIndex;
            item.FloodRisk = request.FloodRisk;

            await _repository.UpdateAsync(item);
            return MapToResponse(item);
        }

        private EODataResponse MapToResponse(EOData e) => new EODataResponse
        {
            Id = e.Id,
            FieldId = e.FieldId,
            Timestamp = e.Timestamp,
            NDVI = e.NDVI,
            SoilMoisture = e.SoilMoisture,
            Rainfall = e.Rainfall,
            Temperature = e.Temperature,
            DroughtIndex = e.DroughtIndex,
            FloodRisk = e.FloodRisk
        };
    }
}

using FarmSightWebApi.ApplicationCore.Domain.Entities;
using FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts;
using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.YieldForecast;
using FarmSightWebApi.ApplicationCore.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Services
{
    public class YieldForecastService : IYieldForecastService
    {
        private readonly IYieldForecastRepository _repository;

        public YieldForecastService(IYieldForecastRepository repository)
        {
            _repository = repository;
        }

        public async Task<YieldForecastResponse> CreateForecastAsync(CreateYieldForecastRequest request)
        {
            var forecast = new YieldForecast
            {
                Id = Guid.NewGuid(),
                FieldId = request.FieldId,
                CropType = request.CropType,
                ForecastDate = request.ForecastDate,
                PredictedHarvestDate = request.PredictedHarvestDate,
                PredictedYieldTons = request.PredictedYieldTons,
                Notes = request.Notes
            };

            await _repository.AddAsync(forecast);
            return MapToResponse(forecast);
        }

        public async Task<bool> DeleteForecastAsync(Guid id)
        {
            var forecast = await _repository.GetByIdAsync(id);
            if (forecast == null) return false;

            await _repository.DeleteAsync(forecast);
            return true;
        }

        public async Task<IEnumerable<YieldForecastResponse>> GetAllAsync()
        {
            var forecasts = await _repository.GetAllAsync();
            return forecasts.Select(MapToResponse);
        }

        public async Task<YieldForecastResponse> GetByIdAsync(Guid id)
        {
            var forecast = await _repository.GetByIdAsync(id);
            return forecast == null ? null : MapToResponse(forecast);
        }

        public async Task<IEnumerable<YieldForecastResponse>> GetByFieldIdAsync(Guid fieldId)
        {
            var forecasts = await _repository.GetByFieldIdAsync(fieldId);
            return forecasts.Select(MapToResponse);
        }

        public async Task<YieldForecastResponse> UpdateForecastAsync(Guid id, UpdateYieldForecastRequest request)
        {
            var forecast = await _repository.GetByIdAsync(id);
            if (forecast == null) return null;

            forecast.CropType = request.CropType;
            forecast.PredictedHarvestDate = request.PredictedHarvestDate;
            forecast.PredictedYieldTons = request.PredictedYieldTons;
            forecast.Notes = request.Notes;

            await _repository.UpdateAsync(forecast);
            return MapToResponse(forecast);
        }

        private YieldForecastResponse MapToResponse(YieldForecast forecast) => new YieldForecastResponse
        {
            Id = forecast.Id,
            FieldId = forecast.FieldId,
            CropType = forecast.CropType,
            ForecastDate = forecast.ForecastDate,
            PredictedHarvestDate = forecast.PredictedHarvestDate,
            PredictedYieldTons = forecast.PredictedYieldTons,
            Notes = forecast.Notes
        };
    }
}

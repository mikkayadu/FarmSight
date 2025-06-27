using FarmSightWebApi.ApplicationCore.Domain.Entities;
using FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts;
using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.CropCalendar;
using FarmSightWebApi.ApplicationCore.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Services
{
    public class CropCalendarService : ICropCalendarService
    {
        private readonly ICropCalendarRepository _repository;

        public CropCalendarService(ICropCalendarRepository repository)
        {
            _repository = repository;
        }

        public async Task<CropCalendarResponse> CreateCalendarAsync(CreateCropCalendarRequest request)
        {
            var calendar = new CropCalendar
            {
                Id = Guid.NewGuid(),
                FieldId = request.FieldId,
                CropType = request.CropType,
                PlantingDate = request.PlantingDate,
                HarvestDate = request.HarvestDate,
                Notes = request.Notes,
                GeneratedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(calendar);
            return MapToResponse(calendar);
        }

        public async Task<bool> DeleteCalendarAsync(Guid id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            await _repository.DeleteAsync(existing);
            return true;
        }

        public async Task<IEnumerable<CropCalendarResponse>> GetAllAsync()
        {
            var calendars = await _repository.GetAllAsync();
            return calendars.Select(MapToResponse);
        }

        public async Task<CropCalendarResponse> GetByIdAsync(Guid id)
        {
            var calendar = await _repository.GetByIdAsync(id);
            return calendar == null ? null : MapToResponse(calendar);
        }

        public async Task<CropCalendarResponse> GetByFieldIdAsync(Guid fieldId)
        {
            var calendar = await _repository.GetByFieldIdAsync(fieldId);
            return calendar == null ? null : MapToResponse(calendar);
        }

        public async Task<CropCalendarResponse> UpdateCalendarAsync(Guid id, UpdateCropCalendarRequest request)
        {
            var calendar = await _repository.GetByIdAsync(id);
            if (calendar == null) return null;

            calendar.CropType = request.CropType;
            calendar.PlantingDate = request.PlantingDate;
            calendar.HarvestDate = request.HarvestDate;
            calendar.Notes = request.Notes;

            await _repository.UpdateAsync(calendar);
            return MapToResponse(calendar);
        }

        private CropCalendarResponse MapToResponse(CropCalendar c) => new CropCalendarResponse
        {
            Id = c.Id,
            FieldId = c.FieldId,
            CropType = c.CropType,
            PlantingDate = c.PlantingDate,
            HarvestDate = c.HarvestDate,
            Notes = c.Notes,
            GeneratedAt = c.GeneratedAt
        };
    }
}

using FarmSightWebApi.ApplicationCore.Domain.Entities;
using FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts;
using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.Alert;
using FarmSightWebApi.ApplicationCore.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Services
{
    public class AlertService : IAlertService
    {
        private readonly IAlertRepository _repository;

        public AlertService(IAlertRepository repository)
        {
            _repository = repository;
        }

        public async Task<AlertResponse> CreateAlertAsync(CreateAlertRequest request)
        {
            var alert = new Alert
            {
                Id = Guid.NewGuid(),
                FieldId = request.FieldId,
                Type = request.Type,
                Message = request.Message,
                AlertLevel = request.AlertLevel,
                Medium = request.Medium,
                SentAt = request.SentAt
            };

            await _repository.AddAsync(alert);
            return MapToResponse(alert);
        }

        public async Task<bool> DeleteAlertAsync(Guid id)
        {
            var alert = await _repository.GetByIdAsync(id);
            if (alert == null) return false;

            await _repository.DeleteAsync(alert);
            return true;
        }

        public async Task<IEnumerable<AlertResponse>> GetAllAsync()
        {
            var alerts = await _repository.GetAllAsync();
            return alerts.Select(MapToResponse);
        }

        public async Task<AlertResponse> GetByIdAsync(Guid id)
        {
            var alert = await _repository.GetByIdAsync(id);
            return alert == null ? null : MapToResponse(alert);
        }

        public async Task<IEnumerable<AlertResponse>> GetByFieldIdAsync(Guid fieldId)
        {
            var alerts = await _repository.GetByFieldIdAsync(fieldId);
            return alerts.Select(MapToResponse);
        }

        public async Task<AlertResponse> UpdateAlertAsync(Guid id, UpdateAlertRequest request)
        {
            var alert = await _repository.GetByIdAsync(id);
            if (alert == null) return null;

            alert.Message = request.Message ?? alert.Message;
            if (request.AlertLevel.HasValue) alert.AlertLevel = request.AlertLevel.Value;
            if (request.Medium.HasValue) alert.Medium = request.Medium.Value;
            if (request.SentAt.HasValue) alert.SentAt = request.SentAt.Value;

            await _repository.UpdateAsync(alert);
            return MapToResponse(alert);
        }

        private AlertResponse MapToResponse(Alert alert) => new AlertResponse
        {
            Id = alert.Id,
            FieldId = alert.FieldId,
            Type = alert.Type,
            Message = alert.Message,
            AlertLevel = alert.AlertLevel,
            Medium = alert.Medium,
            SentAt = alert.SentAt
        };
    }
}

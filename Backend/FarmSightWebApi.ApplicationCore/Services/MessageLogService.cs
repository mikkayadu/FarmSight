using FarmSightWebApi.ApplicationCore.Domain.Entities;
using FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts;
using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.MessageLog;
using FarmSightWebApi.ApplicationCore.DTO.MessageLogye;
using FarmSightWebApi.ApplicationCore.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Services
{
    public class MessageLogService : IMessageLogService
    {
        private readonly IMessageLogRepository _repository;

        public MessageLogService(IMessageLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageLogResponse> CreateAsync(CreateMessageLogRequest request)
        {
            var message = new MessageLog
            {
                Id = Guid.NewGuid(),
                FarmerId = request.FarmerId,
                FieldId = request.FieldId,
                Content = request.Content,
                Medium = request.Medium,
                SentAt = request.SentAt
            };

            await _repository.AddAsync(message);
            return MapToResponse(message);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var msg = await _repository.GetByIdAsync(id);
            if (msg == null) return false;

            await _repository.DeleteAsync(msg);
            return true;
        }

        public async Task<IEnumerable<MessageLogResponse>> GetAllAsync()
        {
            var messages = await _repository.GetAllAsync();
            return messages.Select(MapToResponse);
        }

        public async Task<MessageLogResponse> GetByIdAsync(Guid id)
        {
            var msg = await _repository.GetByIdAsync(id);
            return msg == null ? null : MapToResponse(msg);
        }

        public async Task<IEnumerable<MessageLogResponse>> GetByFarmerIdAsync(Guid farmerId)
        {
            var msgs = await _repository.GetByFarmerIdAsync(farmerId);
            return msgs.Select(MapToResponse);
        }

        public async Task<IEnumerable<MessageLogResponse>> GetByFieldIdAsync(Guid fieldId)
        {
            var msgs = await _repository.GetByFieldIdAsync(fieldId);
            return msgs.Select(MapToResponse);
        }

        public async Task<MessageLogResponse> UpdateAsync(Guid id, UpdateMessageLogRequest request)
        {
            var msg = await _repository.GetByIdAsync(id);
            if (msg == null) return null;

            msg.Content = request.Content ?? msg.Content;
            if (request.Medium.HasValue) msg.Medium = request.Medium.Value;
            if (request.SentAt.HasValue) msg.SentAt = request.SentAt.Value;

            await _repository.UpdateAsync(msg);
            return MapToResponse(msg);
        }

        private MessageLogResponse MapToResponse(MessageLog msg) => new MessageLogResponse
        {
            Id = msg.Id,
            FarmerId = msg.FarmerId,
            FieldId = msg.FieldId,
            Content = msg.Content,
            Medium = msg.Medium,
            SentAt = msg.SentAt
        };
    }
}

using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.MessageLog;
using FarmSightWebApi.ApplicationCore.DTO.MessageLogye;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.ServiceContracts
{
    public interface IMessageLogService
    {
        Task<MessageLogResponse> CreateAsync(CreateMessageLogRequest request);
        Task<MessageLogResponse> UpdateAsync(Guid id, UpdateMessageLogRequest request);
        Task<bool> DeleteAsync(Guid id);
        Task<MessageLogResponse> GetByIdAsync(Guid id);
        Task<IEnumerable<MessageLogResponse>> GetAllAsync();
        Task<IEnumerable<MessageLogResponse>> GetByFarmerIdAsync(Guid farmerId);
        Task<IEnumerable<MessageLogResponse>> GetByFieldIdAsync(Guid fieldId);
    }
}

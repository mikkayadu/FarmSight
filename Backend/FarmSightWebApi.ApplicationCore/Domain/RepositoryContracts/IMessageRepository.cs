using FarmSightWebApi.ApplicationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts
{
    public interface IMessageLogRepository
    {
        Task<MessageLog> AddAsync(MessageLog message);
        Task<MessageLog> GetByIdAsync(Guid id);
        Task<IEnumerable<MessageLog>> GetAllAsync();
        Task<IEnumerable<MessageLog>> GetByFarmerIdAsync(Guid farmerId);
        Task<IEnumerable<MessageLog>> GetByFieldIdAsync(Guid fieldId);
        Task UpdateAsync(MessageLog message);
        Task DeleteAsync(MessageLog message);
    }
}

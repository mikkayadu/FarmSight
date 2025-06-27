using FarmSightWebApi.ApplicationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts
{
    public interface IAlertRepository
    {
        Task<Alert> AddAsync(Alert alert);
        Task<Alert> GetByIdAsync(Guid id);
        Task<IEnumerable<Alert>> GetByFieldIdAsync(Guid fieldId);
        Task<IEnumerable<Alert>> GetAllAsync();
        Task UpdateAsync(Alert alert);
        Task DeleteAsync(Alert alert);
    }
}

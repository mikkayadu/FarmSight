using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.Alert;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.ServiceContracts
{
    public interface IAlertService
    {
        Task<AlertResponse> CreateAlertAsync(CreateAlertRequest request);
        Task<AlertResponse> UpdateAlertAsync(Guid id, UpdateAlertRequest request);
        Task<bool> DeleteAlertAsync(Guid id);
        Task<AlertResponse> GetByIdAsync(Guid id);
        Task<IEnumerable<AlertResponse>> GetByFieldIdAsync(Guid fieldId);
        Task<IEnumerable<AlertResponse>> GetAllAsync();
    }
}

using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.EOData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.ServiceContracts
{
    public interface IEODataService
    {
        Task<EODataResponse> CreateEODataAsync(CreateEODataRequest request);
        Task<EODataResponse> UpdateEODataAsync(Guid id, UpdateEODataRequest request);
        Task<bool> DeleteEODataAsync(Guid id);
        Task<EODataResponse> GetByIdAsync(Guid id);
        Task<IEnumerable<EODataResponse>> GetByFieldIdAsync(Guid fieldId);
        Task<IEnumerable<EODataResponse>> GetAllAsync();
    }
}

using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.Farmer;
using FarmSightWebApi.ApplicationCore.DTO.Farmerye;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.ServiceContracts
{
    public interface IFarmerService
    {
        Task<FarmerResponse> GetFarmerByIdAsync(Guid id);
        Task<IEnumerable<FarmerResponse>> GetAllFarmersAsync();
        Task<FarmerResponse> CreateFarmerAsync(CreateFarmerRequest request);
        Task<FarmerResponse> UpdateFarmerAsync(Guid id, UpdateFarmerRequest request);
        Task<bool> DeleteFarmerAsync(Guid id);
    }
}

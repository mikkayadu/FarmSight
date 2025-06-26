using FarmSightWebApi.ApplicationCore.Domain.Entities;
using FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts;
using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.Farmer;
using FarmSightWebApi.ApplicationCore.DTO.Farmerye;
using FarmSightWebApi.ApplicationCore.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Services
{
    public class FarmerService : IFarmerService
    {
        private readonly IFarmerRepository _farmerRepository;

        public FarmerService(IFarmerRepository farmerRepository)
        {
            _farmerRepository = farmerRepository;
        }

        public async Task<FarmerResponse> CreateFarmerAsync(CreateFarmerRequest request)
        {
            var farmer = new Farmer
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Location = request.Location
            };

            await _farmerRepository.AddAsync(farmer);
            return MapToResponse(farmer);
        }

        public async Task<bool> DeleteFarmerAsync(Guid id)
        {
            var farmer = await _farmerRepository.GetByIdAsync(id);
            if (farmer == null) return false;

            await _farmerRepository.DeleteAsync(farmer);
            return true;
        }

        public async Task<IEnumerable<FarmerResponse>> GetAllFarmersAsync()
        {
            var farmers = await _farmerRepository.GetAllAsync();
            return farmers.Select(MapToResponse);
        }

        public async Task<FarmerResponse> GetFarmerByIdAsync(Guid id)
        {
            var farmer = await _farmerRepository.GetByIdAsync(id);
            return farmer == null ? null : MapToResponse(farmer);
        }

        public async Task<FarmerResponse> UpdateFarmerAsync(Guid id, UpdateFarmerRequest request)
        {
            var farmer = await _farmerRepository.GetByIdAsync(id);
            if (farmer == null) return null;

            farmer.FirstName = request.FirstName;
            farmer.LastName = request.LastName;
            farmer.PhoneNumber = request.PhoneNumber;
            farmer.Email = request.Email;
            farmer.Location = request.Location;

            await _farmerRepository.UpdateAsync(farmer);
            return MapToResponse(farmer);
        }

        private FarmerResponse MapToResponse(Farmer farmer)
        {
            return new FarmerResponse
            {
                Id = farmer.Id,
                FirstName = farmer.FirstName,
                LastName = farmer.LastName,
                PhoneNumber = farmer.PhoneNumber,
                Email = farmer.Email,
                Location = farmer.Location,
                CreatedAt = farmer.CreatedAt
            };
        }
    }
}

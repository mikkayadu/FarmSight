using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamSightWebApi.Core.Domain.Entities;
using FamSightWebApi.Core.Domain.RepositoryContracts;
using FamSightWebApi.Core.DTO;
using FamSightWebApi.Core.Enums;
using FarmSightWebApi.Core.ServiceContracts;

namespace FarmSightWebApi.Application.Services
{
    public class FieldService : IFieldService
    {
        private readonly IFieldRepository _fieldRepository;

        public FieldService(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        public async Task<FieldResponse> CreateFieldAsync(CreateFieldRequest request, Guid farmerId)
        {
            var field = new Field
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CropType = request.CropType,
                Lat1 = request.Lat1,
                Lng1 = request.Lng1,
                Lat2 = request.Lat2,
                Lng2 = request.Lng2,
                Lat3 = request.Lat3,
                Lng3 = request.Lng3,
                Lat4 = request.Lat4,
                Lng4 = request.Lng4,
                CenterLat = (request.Lat1 + request.Lat2 + request.Lat3 + request.Lat4) / 4,
                CenterLng = (request.Lng1 + request.Lng2 + request.Lng3 + request.Lng4) / 4,
                AreaHa = request.AreaHa,
                StartDate = request.StartDate,
                Status = request.Status,
                FarmerId = farmerId
            };

            await _fieldRepository.AddAsync(field);

            return MapToResponse(field);
        }

        public async Task<bool> DeleteFieldAsync(Guid fieldId)
        {
            var field = await _fieldRepository.GetByIdAsync(fieldId);
            if (field == null) return false;

            await _fieldRepository.DeleteAsync(field);
            return true;
        }

        public async Task<IEnumerable<FieldResponse>> GetAllFieldsAsync()
        {
            var fields = await _fieldRepository.GetAllAsync();
            return fields.Select(MapToResponse);
        }

        public async Task<FieldResponse> GetFieldByIdAsync(Guid fieldId)
        {
            var field = await _fieldRepository.GetByIdAsync(fieldId);
            return field == null ? null : MapToResponse(field);
        }

        public async Task<IEnumerable<FieldResponse>> GetFieldsByFarmerAsync(Guid farmerId)
        {
            var fields = await _fieldRepository.GetByUserIdAsync(farmerId);
            return fields.Select(MapToResponse);
        }

        public async Task<IEnumerable<FieldResponse>> GetFieldsWithinRadiusAsync(double lat, double lon, double radiusKm)
        {
            var fields = await _fieldRepository.GetWithinBoundingBoxAsync(lat, lon, radiusKm);
            return fields.Select(MapToResponse);
        }

        public async Task<FieldResponse> GetFieldByCentroidAsync(double lat, double lng)
        {
            var field = await _fieldRepository.GetByCentroidAsync(lat, lng);
            return field == null ? null : MapToResponse(field);
        }

        public async Task<FieldResponse> UpdateFieldAsync(Guid fieldId, UpdateFieldRequest request)
        {
            var field = await _fieldRepository.GetByIdAsync(fieldId);
            if (field == null) return null;

            field.Name = request.Name;
            field.CropType = request.CropType;
            field.Lat1 = request.Lat1;
            field.Lng1 = request.Lng1;
            field.Lat2 = request.Lat2;
            field.Lng2 = request.Lng2;
            field.Lat3 = request.Lat3;
            field.Lng3 = request.Lng3;
            field.Lat4 = request.Lat4;
            field.Lng4 = request.Lng4;
            field.CenterLat = (request.Lat1 + request.Lat2 + request.Lat3 + request.Lat4) / 4;
            field.CenterLng = (request.Lng1 + request.Lng2 + request.Lng3 + request.Lng4) / 4;
            field.AreaHa = request.AreaHa;
            field.StartDate = request.StartDate;

            await _fieldRepository.UpdateAsync(field);

            return MapToResponse(field);
        }

        private FieldResponse MapToResponse(Field field)
        {
            return new FieldResponse
            {
                Id = field.Id,
                Name = field.Name,
                CropType = field.CropType,
                Lat1 = field.Lat1,
                Lng1 = field.Lng1,
                Lat2 = field.Lat2,
                Lng2 = field.Lng2,
                Lat3 = field.Lat3,
                Lng3 = field.Lng3,
                Lat4 = field.Lat4,
                Lng4 = field.Lng4,
                CenterLat = field.CenterLat,
                CenterLng = field.CenterLng,
                AreaHa = field.AreaHa,
                StartDate = field.StartDate,
                UserId = field.FarmerId
            };
        }
    }
}

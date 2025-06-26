using FarmSightWebApi.ApplicationCore.DTO.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.ServiceContracts
{
    public interface IFieldService
    {
        Task<FieldResponse> GetFieldByIdAsync(Guid fieldId);
        Task<IEnumerable<FieldResponse>> GetFieldsByFarmerAsync(Guid farmerId);
        Task<IEnumerable<FieldResponse>> GetAllFieldsAsync();

        Task<FieldResponse> CreateFieldAsync(CreateFieldRequest request, Guid farmerId);
        Task<FieldResponse> UpdateFieldAsync(Guid fieldId, UpdateFieldRequest request);
        Task<bool> DeleteFieldAsync(Guid fieldId);

        Task<IEnumerable<FieldResponse>> GetFieldsWithinRadiusAsync(double lat, double lon, double radiusKm);
        Task<FieldResponse> GetFieldByCentroidAsync(double lat, double lng);
    }
}

using FamSightWebApi.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSightWebApi.Core.ServiceContracts
{
    public interface IFieldService
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
}

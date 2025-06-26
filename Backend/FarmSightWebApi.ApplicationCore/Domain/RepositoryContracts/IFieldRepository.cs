using FarmSightWebApi.ApplicationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts
{
    public interface IFieldRepository
    {
        Task<Field> GetByIdAsync(Guid id);
        Task<IEnumerable<Field>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<Field>> GetAllAsync();
        Task AddAsync(Field field);
        Task UpdateAsync(Field field);
        Task DeleteAsync(Field field);
        Task<bool> ExistsAsync(Guid fieldId);
        Task<IEnumerable<Field>> GetWithinBoundingBoxAsync(double lat, double lon, double radiusKm);
        Task<Field?> GetByCentroidAsync(double lat, double lng);
    }
}

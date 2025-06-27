using FarmSightWebApi.ApplicationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Domain.RepositoryContracts
{
    public interface ICropCalendarRepository
    {
        Task<CropCalendar> AddAsync(CropCalendar calendar);
        Task<CropCalendar> GetByIdAsync(Guid id);
        Task<CropCalendar> GetByFieldIdAsync(Guid fieldId);
        Task<IEnumerable<CropCalendar>> GetAllAsync();
        Task UpdateAsync(CropCalendar calendar);
        Task DeleteAsync(CropCalendar calendar);
    }
}

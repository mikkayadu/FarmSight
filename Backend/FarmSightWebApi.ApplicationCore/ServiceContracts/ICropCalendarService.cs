using FarmSightWebApi.ApplicationCore.DTO;
using FarmSightWebApi.ApplicationCore.DTO.CropCalendar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.ServiceContracts
{
    public interface ICropCalendarService
    {
        Task<CropCalendarResponse> CreateCalendarAsync(CreateCropCalendarRequest request);
        Task<CropCalendarResponse> UpdateCalendarAsync(Guid id, UpdateCropCalendarRequest request);
        Task<bool> DeleteCalendarAsync(Guid id);
        Task<CropCalendarResponse> GetByIdAsync(Guid id);
        Task<CropCalendarResponse> GetByFieldIdAsync(Guid fieldId);
        Task<IEnumerable<CropCalendarResponse>> GetAllAsync();
    }
}

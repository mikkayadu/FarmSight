using System;

namespace FarmSightWebApi.ApplicationCore.DTO.CropCalendar
{
    public class UpdateCropCalendarRequest
    {
        public string CropType { get; set; }
        public DateTime PlantingDate { get; set; }
        public DateTime HarvestDate { get; set; }
        public string Notes { get; set; }
    }
}

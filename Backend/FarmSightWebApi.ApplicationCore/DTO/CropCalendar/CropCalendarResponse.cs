using System;

namespace FarmSightWebApi.ApplicationCore.DTO.CropCalendar
{
    public class CropCalendarResponse
    {
        public Guid Id { get; set; }
        public Guid FieldId { get; set; }
        public string CropType { get; set; }

        public DateTime PlantingDate { get; set; }
        public DateTime HarvestDate { get; set; }
        public DateTime GeneratedAt { get; set; }

        public string Notes { get; set; }
    }
}

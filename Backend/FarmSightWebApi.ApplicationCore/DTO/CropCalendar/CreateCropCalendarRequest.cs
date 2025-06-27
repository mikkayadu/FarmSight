using System;
using System.ComponentModel.DataAnnotations;

namespace FarmSightWebApi.ApplicationCore.DTO.CropCalendar
{
    public class CreateCropCalendarRequest
    {
        [Required] public Guid FieldId { get; set; }
        [Required] public string CropType { get; set; }

        public DateTime PlantingDate { get; set; }
        public DateTime HarvestDate { get; set; }
        public string Notes { get; set; }
    }
}

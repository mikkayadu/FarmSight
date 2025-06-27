using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmSightWebApi.ApplicationCore.Domain.Entities
{
    public class CropCalendar
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(Field))]
        public Guid FieldId { get; set; }
        public Field FarmField { get; set; }

        public DateTime PlantingDate { get; set; }
        public DateTime HarvestDate { get; set; }
        public string CropType { get; set; }

        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
        public string Notes { get; set; }
    }
}

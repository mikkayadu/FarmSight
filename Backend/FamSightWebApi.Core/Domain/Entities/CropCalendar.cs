using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamSightWebApi.Core.Domain.Entities
{
    public class CropCalendar
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(Field))]
        public Guid FieldId { get; set; }
        public Field FarmField { get; set; }

        public DateTime SowingDate { get; set; }
        public DateTime HarvestDate { get; set; }

        public bool IsDynamic { get; set; } = true;
        public string WeatherNotes { get; set; }
    }
}

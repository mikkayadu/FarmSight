using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamSightWebApi.Core.Domain.Entities
{
    public class CropCalendar
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid FieldId { get; set; }
        public Field Field { get; set; }

        public DateTime SowingDate { get; set; }
        public DateTime HarvestDate { get; set; }

        public bool IsDynamic { get; set; } = true;
        public string WeatherNotes { get; set; }
    }
}

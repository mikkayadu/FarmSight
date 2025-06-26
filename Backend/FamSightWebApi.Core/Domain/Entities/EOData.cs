using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamSightWebApi.Core.Domain.Entities
{
    public class EOData
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(Field))]
        public Guid FieldId { get; set; }
        public Field FarmField { get; set; }

        public DateTime Timestamp { get; set; }

        public float NDVI { get; set; }
        public float SoilMoisture { get; set; }
        public float Rainfall { get; set; }
        public float Temperature { get; set; }
        public float DroughtIndex { get; set; }
        public float FloodRisk { get; set; }
    }
}

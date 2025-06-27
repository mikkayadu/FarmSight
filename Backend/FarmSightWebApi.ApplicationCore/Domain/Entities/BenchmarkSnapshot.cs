using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Domain.Entities
{
    public class BenchmarkSnapshot
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(Field))]
        public Guid FieldId { get; set; }
        public Field Field { get; set; }

        public DateTime SnapshotDate { get; set; }

        public float AvgNDVI { get; set; }
        public float AvgMoisture { get; set; }
        public int FieldCount { get; set; }
    }
}

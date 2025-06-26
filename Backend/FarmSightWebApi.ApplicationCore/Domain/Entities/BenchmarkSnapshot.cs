using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Domain.Entities
{
    public class BenchmarkSnapshot
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string RegionCode { get; set; }
        public string CropType { get; set; }
        public DateTime Date { get; set; }

        public float AvgNDVI { get; set; }
        public float AvgMoisture { get; set; }
        public int FieldCount { get; set; }
    }
}

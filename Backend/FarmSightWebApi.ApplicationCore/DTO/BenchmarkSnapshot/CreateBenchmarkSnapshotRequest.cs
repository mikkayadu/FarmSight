using System;
using System.ComponentModel.DataAnnotations;

namespace FarmSightWebApi.ApplicationCore.DTO.BenchmarkSnapshot
{
    public class CreateBenchmarkSnapshotRequest
    {
        [Required]
        public Guid FieldId { get; set; }

        [Required]
        public DateTime SnapshotDate { get; set; }

        [Required]
        public float AvgNDVI { get; set; }

        [Required]
        public float AvgMoisture { get; set; }

        [Required]
        public int FieldCount { get; set; }
    }
}

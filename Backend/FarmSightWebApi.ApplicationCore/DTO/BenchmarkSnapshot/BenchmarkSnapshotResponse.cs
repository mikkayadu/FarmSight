using System;

namespace FarmSightWebApi.ApplicationCore.DTO.BenchmarkSnapshot
{
    public class BenchmarkSnapshotResponse
    {
        public Guid Id { get; set; }
        public Guid FieldId { get; set; }
        public DateTime SnapshotDate { get; set; }
        public float AvgNDVI { get; set; }
        public float AvgMoisture { get; set; }
        public int FieldCount { get; set; }
    }
}

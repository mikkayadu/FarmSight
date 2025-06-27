using System;

namespace FarmSightWebApi.ApplicationCore.DTO.BenchmarkSnapshot
{
    public class UpdateBenchmarkSnapshotRequest
    {
        public float? AvgNDVI { get; set; }
        public float? AvgMoisture { get; set; }
        public int? FieldCount { get; set; }
    }
}

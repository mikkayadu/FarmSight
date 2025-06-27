using System;

namespace FarmSightWebApi.ApplicationCore.DTO.EOData
{
    public class EODataResponse
    {
        public Guid Id { get; set; }
        public Guid FieldId { get; set; }
        public DateTime Timestamp { get; set; }

        public float NDVI { get; set; }
        public float SoilMoisture { get; set; }
        public float Rainfall { get; set; }
        public float Temperature { get; set; }
        public float DroughtIndex { get; set; }
        public float FloodRisk { get; set; }
    }
}

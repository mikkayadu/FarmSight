using System;
using System.ComponentModel.DataAnnotations;

namespace FarmSightWebApi.ApplicationCore.DTO.EOData
{
    public class CreateEODataRequest
    {
        [Required] public Guid FieldId { get; set; }
        [Required] public DateTime Timestamp { get; set; }

        public float NDVI { get; set; }
        public float SoilMoisture { get; set; }
        public float Rainfall { get; set; }
        public float Temperature { get; set; }
        public float DroughtIndex { get; set; }
        public float FloodRisk { get; set; }
    }
}

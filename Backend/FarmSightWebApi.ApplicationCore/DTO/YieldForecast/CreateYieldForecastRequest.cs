using System;
using System.ComponentModel.DataAnnotations;

namespace FarmSightWebApi.ApplicationCore.DTO.YieldForecast
{
    public class CreateYieldForecastRequest
    {
        [Required] public Guid FieldId { get; set; }
        public string CropType { get; set; }
        public float PredictedYieldTons { get; set; }
        public DateTime ForecastDate { get; set; } = DateTime.UtcNow;
        public DateTime PredictedHarvestDate { get; set; }
        public string Notes { get; set; }
    }
}

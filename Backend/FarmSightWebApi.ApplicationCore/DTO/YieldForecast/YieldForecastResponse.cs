using System;

namespace FarmSightWebApi.ApplicationCore.DTO.YieldForecast
{
    public class YieldForecastResponse
    {
        public Guid Id { get; set; }
        public Guid FieldId { get; set; }
        public string CropType { get; set; }

        public DateTime ForecastDate { get; set; }
        public DateTime PredictedHarvestDate { get; set; }

        public float PredictedYieldTons { get; set; }
        public string Notes { get; set; }
    }
}

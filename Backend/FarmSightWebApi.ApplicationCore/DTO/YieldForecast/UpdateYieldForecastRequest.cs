using System;
using System.ComponentModel.DataAnnotations;

namespace FarmSightWebApi.ApplicationCore.DTO.YieldForecast
{
    public class UpdateYieldForecastRequest
    {
        public string CropType { get; set; }
        public float PredictedYieldTons { get; set; }
        public DateTime PredictedHarvestDate { get; set; }
        public string Notes { get; set; }
    }
}

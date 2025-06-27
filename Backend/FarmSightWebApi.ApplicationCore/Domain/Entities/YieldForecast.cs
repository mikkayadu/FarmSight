using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmSightWebApi.ApplicationCore.Domain.Entities
{
    public class YieldForecast
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(Field))]
        public Guid FieldId { get; set; }
        public Field FarmField { get; set; }

        public DateTime ForecastDate { get; set; }   // When this forecast was made
        public DateTime PredictedHarvestDate { get; set; } // Estimated harvest window

        public float PredictedYieldTons { get; set; }
        public string CropType { get; set; }
        public string Notes { get; set; }
    }
}

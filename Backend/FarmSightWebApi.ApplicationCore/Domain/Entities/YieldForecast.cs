using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Domain.Entities
{
    public class YieldForecast
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid FieldId { get; set; }
        public Field Field { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ForecastDate { get; set; }

        public float ExpectedYield { get; set; } // tons/ha
        public float Confidence { get; set; }
        public string MarketTip { get; set; }
    }
}

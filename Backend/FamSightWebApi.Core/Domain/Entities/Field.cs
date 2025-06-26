using FamSightWebApi.Core.Enums;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamSightWebApi.Core.Domain.Entities
{
    public class Field
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(Farmer))]
        public Guid FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        public string Name { get; set; }
        public string CropType { get; set; }
        public double Lat1 { get; set; }
        public double Lng1 { get; set; }

        public double Lat2 { get; set; }
        public double Lng2 { get; set; }

        public double Lat3 { get; set; }
        public double Lng3 { get; set; }

        public double Lat4 { get; set; }
        public double Lng4 { get; set; }
        public double CenterLat { get; set; }
        public double CenterLng { get; set; }
        public double AreaHa { get; set; }
        public DateTime? StartDate { get; set; }
        public FieldStatus Status { get; set; }

        public ICollection<EOData> EOData { get; set; }
        public ICollection<YieldForecast> YieldForecasts { get; set; }
        public ICollection<Alert> Alerts { get; set; }
        public CropCalendar CropCalendar { get; set; }

    }
}

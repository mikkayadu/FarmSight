using FarmSightWebApi.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.DTO.Field
{
    public class CreateFieldRequest
    {
        public string Name { get; set; }
        public string CropType { get; set; }

        // Coordinates of the 4 corners
        public double Lat1 { get; set; }
        public double Lng1 { get; set; }

        public double Lat2 { get; set; }
        public double Lng2 { get; set; }

        public double Lat3 { get; set; }
        public double Lng3 { get; set; }

        public double Lat4 { get; set; }
        public double Lng4 { get; set; }

        public double AreaHa { get; set; }
        public DateTime? StartDate { get; set; }
        public FieldStatus Status { get; set; } = FieldStatus.active;
    }

}

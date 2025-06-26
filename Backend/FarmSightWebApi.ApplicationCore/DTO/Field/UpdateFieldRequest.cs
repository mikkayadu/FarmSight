using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.DTO.Field
{
    public class UpdateFieldRequest
    {
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

        public double AreaHa { get; set; }
        public DateTime? StartDate { get; set; }
        public string Status { get; set; }
    }

}

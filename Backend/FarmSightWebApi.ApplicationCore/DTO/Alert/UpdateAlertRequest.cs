using FarmSightWebApi.ApplicationCore.Enums;
using System;

namespace FarmSightWebApi.ApplicationCore.DTO.Alert
{
    public class UpdateAlertRequest
    {
        public string Message { get; set; }
        public AlertLevel? AlertLevel { get; set; }
        public MessageMedium? Medium { get; set; }
        public DateTime? SentAt { get; set; }
    }
}

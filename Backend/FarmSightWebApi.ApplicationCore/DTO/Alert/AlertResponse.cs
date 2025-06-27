using FarmSightWebApi.ApplicationCore.Enums;
using System;

namespace FarmSightWebApi.ApplicationCore.DTO.Alert
{
    public class AlertResponse
    {
        public Guid Id { get; set; }
        public Guid FieldId { get; set; }

        public AlertType Type { get; set; }
        public string Message { get; set; }
        public AlertLevel AlertLevel { get; set; }
        public MessageMedium Medium { get; set; }

        public DateTime SentAt { get; set; }
    }
}

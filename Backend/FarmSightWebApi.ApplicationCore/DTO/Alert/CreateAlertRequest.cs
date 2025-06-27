using FarmSightWebApi.ApplicationCore.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace FarmSightWebApi.ApplicationCore.DTO.Alert
{
    public class CreateAlertRequest
    {
        [Required]
        public Guid FieldId { get; set; }

        [Required]
        public AlertType Type { get; set; }

        [Required]
        public AlertLevel AlertLevel { get; set; }

        [Required]
        public MessageMedium Medium { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}

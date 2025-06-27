using FarmSightWebApi.ApplicationCore.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace FarmSightWebApi.ApplicationCore.DTO.MessageLog
{
    public class CreateMessageLogRequest
    {
        [Required]
        public Guid FarmerId { get; set; }

        public Guid? FieldId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public MessageMedium Medium { get; set; }

        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}

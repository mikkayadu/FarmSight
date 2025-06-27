using FarmSightWebApi.ApplicationCore.Enums;
using System;

namespace FarmSightWebApi.ApplicationCore.DTO.MessageLogye
{
    public class UpdateMessageLogRequest
    {
        public string Content { get; set; }
        public MessageMedium? Medium { get; set; }
        public DateTime? SentAt { get; set; }
    }
}

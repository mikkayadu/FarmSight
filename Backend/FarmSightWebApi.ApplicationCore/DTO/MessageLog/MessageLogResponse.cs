using FarmSightWebApi.ApplicationCore.Enums;
using System;

namespace FarmSightWebApi.ApplicationCore.DTO.MessageLog
{
    public class MessageLogResponse
    {
        public Guid Id { get; set; }
        public Guid FarmerId { get; set; }
        public Guid? FieldId { get; set; }
        public string Content { get; set; }
        public MessageMedium Medium { get; set; }
        public DateTime SentAt { get; set; }
    }
}

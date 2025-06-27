using FarmSightWebApi.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Domain.Entities
{
    public class MessageLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        public Guid? FieldId { get; set; }
        public Field Field { get; set; }

        public string Content { get; set; }
        public MessageMedium Medium { get; set; } // sms / whatsapp / api
        public DateTime SentAt { get; set; }
    }
}

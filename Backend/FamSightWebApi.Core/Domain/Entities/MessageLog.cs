using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamSightWebApi.Core.Domain.Entities
{
    public class MessageLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public Farmer Farmer { get; set; }

        public Guid? FieldId { get; set; }
        public Field Field { get; set; }

        public string Content { get; set; }
        public string Medium { get; set; } // sms / whatsapp / api
        public DateTime SentAt { get; set; }
    }
}

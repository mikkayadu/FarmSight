using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamSightWebApi.Core.Domain.Entities
{
    public class Alert
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid FieldId { get; set; }
        public Field Field { get; set; }

        public string Type { get; set; } // ndvi_drop / drought / flood
        public string Message { get; set; }
        public string AlertLevel { get; set; } // info / warning / critical
        public string Method { get; set; } // sms / whatsapp
        public DateTime SentAt { get; set; }
    }
}

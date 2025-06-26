using FarmSightWebApi.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Domain.Entities
{
    public class Alert
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(Field))]
        public Guid FieldId { get; set; }
        public Field FarmField { get; set; }

        public AlertType Type { get; set; } // ndvi_drop / drought / flood
        public string Message { get; set; }
        public AlertLevel AlertLevel { get; set; } // info / warning / critical
        public MessageMedium Medium { get; set; } // sms / whatsapp
        [DataType(DataType.DateTime)]
        public DateTime SentAt { get; set; }
    }
}

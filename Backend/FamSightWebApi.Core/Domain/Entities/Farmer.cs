using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamSightWebApi.Core.Domain.Entities
{
    public class Farmer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Region { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Field> Fields { get; set; }
        public ICollection<MessageLog> Messages { get; set; }
    }
}

using FarmSightWebApi.ApplicationCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public Guid FarmerId { get; set; }
        public virtual Farmer Farmer { get; set; }
    }
}

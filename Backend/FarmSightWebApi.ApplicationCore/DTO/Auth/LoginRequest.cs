using System.ComponentModel.DataAnnotations;

namespace FarmSightWebApi.ApplicationCore.DTO
{
    public class LoginRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace FarmSightWebApi.ApplicationCore.DTO.Auth
{
    public class RegisterRequest
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required, EmailAddress] public string Email { get; set; }
        [Required] public string PhoneNumber { get; set; }
        public string Location { get; set; }
        [Required] public string Password { get; set; }
    }
}

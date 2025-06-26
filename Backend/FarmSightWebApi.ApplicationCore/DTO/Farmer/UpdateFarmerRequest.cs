using System.ComponentModel.DataAnnotations;

namespace FarmSightWebApi.ApplicationCore.DTO.Farmer
{
    public class UpdateFarmerRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Location { get; set; }
    }
}

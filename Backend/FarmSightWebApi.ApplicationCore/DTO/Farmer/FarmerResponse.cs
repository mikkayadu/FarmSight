using System;

namespace FarmSightWebApi.ApplicationCore.DTO.Farmerye
{
    public class FarmerResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

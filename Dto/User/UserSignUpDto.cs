using Jobify.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobify.Dto.User
{
    public class UserSignUpDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string DateOfBirth { get; set; }
        public string Description { get; set; }
        public string Adresse { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int? JobId { get; set; }
    }
}


using System.ComponentModel.DataAnnotations.Schema;

namespace Jobify.Dto.Post
{
    public class UserForPostDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public double AverageRating { get; set; }
    }
}

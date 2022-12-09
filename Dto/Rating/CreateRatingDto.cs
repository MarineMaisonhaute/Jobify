using System.ComponentModel.DataAnnotations.Schema;

namespace Jobify.Dto.Rating
{
    public class CreateRatingDto
    {
        public string Comment { get; set; }
        public int Note { get; set; }
    }
}

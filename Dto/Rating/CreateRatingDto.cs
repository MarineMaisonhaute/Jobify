using System.ComponentModel.DataAnnotations.Schema;

namespace Jobify.Dto.Rating
{
    public class CreateRatingDto
    {
        public Guid RatedUserId { get; set; }
        public int PostId { get; set; }
        public int Note { get; set; }
    }
}

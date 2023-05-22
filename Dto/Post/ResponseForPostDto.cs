using System.ComponentModel.DataAnnotations.Schema;

namespace Jobify.Dto.Post
{
    public class ResponseForPostDto
    {
        public int ResponseId { get; set; }
        public UserForPostDto User { get; set; }
        public Guid UserId { get; set; }
        public int PostId { get; set; }
        public string Comment { get; set; }
    }
}

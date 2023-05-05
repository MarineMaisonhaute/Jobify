using System.ComponentModel.DataAnnotations.Schema;

namespace Jobify.Models
{
    public class Response
    {
        public int ResponseId { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int? PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
        public string Comment { get; set; }
    }
}

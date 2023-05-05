using System.ComponentModel.DataAnnotations.Schema;

namespace Jobify.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }
        public int JobId { get; set; }
        [ForeignKey("JobId")]
        public Job Job { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int Price { get; set; }
        public DateTime FinishDate { get; set; }
        public string Department { get; set; }

    }
}

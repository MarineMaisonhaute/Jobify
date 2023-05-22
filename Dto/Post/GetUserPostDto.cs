using System.ComponentModel.DataAnnotations.Schema;

namespace Jobify.Dto.Post
{
    public class GetUserPostDto
    {
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }
        public int Price { get; set; }
        public DateTime FinishDate { get; set; }
        public string Department { get; set; }
        public ICollection<ResponseForPostDto> Responses { get; set; }
    }
}

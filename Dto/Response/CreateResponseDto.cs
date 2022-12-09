using System.ComponentModel.DataAnnotations.Schema;

namespace Jobify.Dto.Response
{
    public class CreateResponseDto
    { 
        public int PostId { get; set; }
        public string Comment { get; set; }
    }
}

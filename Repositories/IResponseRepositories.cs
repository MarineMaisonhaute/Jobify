using Jobify.Dto.Post;
using Jobify.Dto.Response;
using Jobify.Models;

namespace Jobify.Repositories
{
    public interface IResponseRepositories
    {
        Response GetResponseById(int id);
        List<Response> GetResponse();
        void CreateResponse(Response newResponse);
        void UpdateResponse(UpdateResponseDto newResponse, int oldResponseId );
        void DeleteResponse(int responseid);

    }
}

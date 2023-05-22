using AutoMapper;
using Jobify.DBContext;
using Jobify.Dto.Job;
using Jobify.Dto.Post;
using Jobify.Dto.Response;
using Jobify.Models;

namespace Jobify.Repositories
{
    public class ResponseRepositories : IResponseRepositories
    {
        private readonly JobifyDBContext _context;
        private readonly IMapper _mapper;
        public ResponseRepositories(JobifyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Response GetResponseById(int id)
        {
            return _context.Response.Where(r => r.ResponseId == id).FirstOrDefault();
        }

        public void CreateResponse(Response newResponse)
        {
            _context.Response.Add(newResponse);
            _context.SaveChanges();
        }
        public List<Response> GetResponse()
        {
            return _context.Response.ToList();
        }
        public void UpdateResponse(UpdateResponseDto newResponse, int oldResponseId)
        {
            Response response = GetResponseById(oldResponseId);
            _context.Response.Update(response);
            _context.SaveChanges();
        }
        public void DeleteResponse(int responseId)
        {
            Response response = GetResponseById(responseId);
            _context.Response.Remove(response);
            _context.SaveChanges();
        }
    }
}


using AutoMapper;
using Jobify.Dto.Rating;
using Jobify.Dto.Response;
using Jobify.Models;
using Jobify.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Jobify.Controllers
{
    [ApiController]
    [Route("response")]
    public class ResponseController : Controller
    {
        private readonly IResponseRepositories _responseRepositories;
        private readonly IMapper _mapper;

        public ResponseController(IResponseRepositories responseRepositories, IMapper mapper)
        {
            _responseRepositories = responseRepositories;
            _mapper = mapper;
        }
        [HttpPost]
        public ActionResult CreateResponse(CreateResponseDto responseDto)
        {
            Response response = _mapper.Map<Response>(responseDto);

            _responseRepositories.CreateResponse(response);

            return Ok();
        }
        [HttpGet("{responseId}")]
        public ActionResult<Response> GetResponseById(int responseId)
        {
            Response response = _responseRepositories.GetResponseById(responseId);
            if (response == null)
            {
                return NotFound();
            }
            return _responseRepositories.GetResponseById(responseId);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Response>> GetResponse()
        {
            return Ok(_responseRepositories.GetResponse());
        }
        [HttpPut("{responseId}")]
        public ActionResult UpdateResponse(UpdateResponseDto responseDto, int responseID)
        {
            _responseRepositories.UpdateResponse(responseDto, responseID);
            return NoContent();
        }

        [HttpDelete("{responseId}")]
        public ActionResult DeleteResponse(int responseId)
        {
            _responseRepositories.DeleteResponse(responseId);
            return NoContent();
        }
    }
}

using AutoMapper;
using Jobify.Dto.Job;
using Jobify.Dto.Post;
using Jobify.Dto.Rating;
using Jobify.Models;
using Jobify.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace Jobify.Controllers
{
    [ApiController]
    [Route("rating")]
    public class RatingController : Controller
    {
        private readonly IRatingRepositories _ratingRepositories;
        private readonly IPostRepositories _postRepository;
        private readonly IMapper _mapper;
        public RatingController(IRatingRepositories ratingRepositories, IMapper mapper, IPostRepositories postRepository)
        {
            _ratingRepositories = ratingRepositories;
            _mapper = mapper;
            _postRepository = postRepository;
        }
        [HttpPost]
        public ActionResult CreateRating(CreateRatingDto ratingDto)
        {
            Rating? ratingCheck = _ratingRepositories.GetRatingByPostUsersIds(ratingDto.RatedUserId, Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)), ratingDto.PostId);

            if(ratingCheck != null)
            {
                return BadRequest("Utilisateur déjà noté pour ce post.");
            }

            Rating rating = _mapper.Map<Rating>(ratingDto);

            rating.RaterUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Post post = _postRepository.GetPostById(ratingDto.PostId);

            if (post.UserId != Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return BadRequest("Not your post.");
            }

            rating.RatedUserId = ratingDto.RatedUserId;

            _ratingRepositories.CreateRating(rating);

            return Ok();
        }
        [HttpGet("{ratingId}")]
        public ActionResult<Rating> GetRatingById(int ratingId)
        {
            Rating rating = _ratingRepositories.GetRatingById(ratingId);
            if (rating == null)
            {
                return NotFound();
            }
            return _ratingRepositories.GetRatingById(ratingId);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Rating>> GetRating()
        {
            return Ok(_ratingRepositories.GetRating());
        }
        [HttpPut("{ratingId}")]
        public ActionResult UpdateRating(UpdateRatingDto ratingDto, int ratingID)
        {
            _ratingRepositories.UpdateRating(ratingDto, ratingID);
            return NoContent();
        }

        [HttpDelete("{ratingId}")]
        public ActionResult DeleteRating(int ratingId)
        {
            _ratingRepositories.DeleteRating(ratingId);
            return NoContent();
        }
    }
}

using AutoMapper;
using Jobify.Dto.Post;
using Jobify.Models;
using Jobify.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Jobify.Controllers
{
    [ApiController]
    [Route("post")]
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostRepositories _postRepositories;
        private readonly IMapper _mapper;
        private readonly IRatingRepositories _ratingRepositories;

        public PostController(IPostRepositories postRepositories, IMapper mapper, IRatingRepositories ratingRepositories)
        {
            _postRepositories = postRepositories;
            _mapper = mapper;
            _ratingRepositories = ratingRepositories;
        }

        [HttpPost]
        public ActionResult CreatePost(CreatePostDto postDto)
        {
            Post post = _mapper.Map<Post>(postDto);

            post.UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            _postRepositories.CreatePost(post);

            return Ok();
        }
        [HttpGet("{postId}")]
        public ActionResult<Post> GetPosttById(int postId)
        {
            Post post = _postRepositories.GetPostById(postId);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpGet("user")]
        public ActionResult<IEnumerable<GetUserPostDto>> GetPostsByUserId()
        {
            IEnumerable<Post> posts = _postRepositories.GetPostByUserId(Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));

            IEnumerable<GetUserPostDto> getPostDto = _mapper.Map<IEnumerable<GetUserPostDto>>(posts);

            foreach (var post in getPostDto)
            {
                foreach(var response in post.Responses)
                {
                    response.User.AverageRating = _ratingRepositories.GetAverageRatingByUserId(response.UserId);
                }
            }

            return Ok(getPostDto);
        }

        [HttpGet("date")]
        public ActionResult<Post> GetPosttAfterDate(DateTime date)
        {
            IEnumerable<Post> posts = _postRepositories.GetPostAfterDate(date);
            if (posts == null)
            {
                return NotFound();
            }
            return Ok(posts);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetPost()
        {
            return Ok(_postRepositories.GetPosts());
        }
        [HttpPut("{postId}")]
        public ActionResult UpdatePost(UpdatePostDto postDto, int postID)
        {
            _postRepositories.UpdatePost(postDto, postID);
            return NoContent();
        }

        [HttpDelete("{postId}")]
        public ActionResult DeletePost(int postId)
        {
            _postRepositories.DeletePost(postId);
            return NoContent();
        }
    }
}

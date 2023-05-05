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
    public class PostController : Controller
    {
        private readonly IPostRepositories _postRepositories;
        private readonly IMapper _mapper;
        public PostController(IPostRepositories postRepositories, IMapper mapper)
        {
            _postRepositories = postRepositories;
            _mapper = mapper;
        }

        [Authorize]
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
            return _postRepositories.GetPostById(postId);
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

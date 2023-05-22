using AutoMapper;
using Jobify.DBContext;
using Jobify.Dto.Post;
using Jobify.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobify.Repositories
{
    public class PostRepositories : IPostRepositories
    {
        private readonly JobifyDBContext _context;
        private readonly IMapper _mapper;
        public PostRepositories(JobifyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Post GetPostById (int id)
        {
            return _context.Post.Where(p => p.PostId == id).FirstOrDefault();
        }
        public void CreatePost(Post newPost)
        {
            _context.Post.Add(newPost);
            _context.SaveChanges();
        }
        public List<Post> GetPosts()
        {
            return _context.Post.ToList();
        }

        public IEnumerable<Post> GetPostByUserId(Guid userId)
        {
            return _context.Post.Where(p => p.UserId == userId).Include(p => p.Responses).ThenInclude(r => r.User);
        }

        public void UpdatePost(UpdatePostDto newPost, int oldPostId)
        {
            Post post = GetPostById(oldPostId);

            _mapper.Map(newPost, post);

            _context.SaveChanges();
        }

        public void DeletePost(int PostId)
        {
            Post post = GetPostById(PostId);
            _context.Post.Remove(post);
            _context.SaveChanges();
        }
    }
}

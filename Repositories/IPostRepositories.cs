using Jobify.Dto.Post;
using Jobify.Models;

namespace Jobify.Repositories
{
    public interface IPostRepositories
    {
        Post GetPostById(int id);
        List<Post> GetPosts();

        IEnumerable<Post> GetPostByUserId(Guid userId);
        void CreatePost(Post newPost);
        void UpdatePost(UpdatePostDto newPost, int oldPostId);
        void DeletePost(int id);
    }
}

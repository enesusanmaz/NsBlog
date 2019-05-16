using NsBlog.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NsBlog.Data.Abstract
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(int postId);
        Task CreatePostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(Post post);
    }
}

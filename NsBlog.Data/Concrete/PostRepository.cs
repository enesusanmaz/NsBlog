using Microsoft.EntityFrameworkCore;
using NsBlog.Data.Abstract;
using NsBlog.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NsBlog.Data.Concrete
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(NsBlogContext repositoryContext)
       : base(repositoryContext)
        {
        }


        public async Task CreatePostAsync(Post post)
        {
            Create(post);
            await SaveAsync();
        }

        public async Task DeletePostAsync(Post post)
        {
            Delete(post);
            await SaveAsync();
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(int postId)
        {
            return await FindByCondition(o => o.Id == postId)
              .DefaultIfEmpty(new Post())
              .SingleAsync();
        }

        public async Task UpdatePostAsync(Post post)
        {
            Update(post);
            await SaveAsync();
        }
    }
}


using Blog.Data.Contracts;
using Blog.Data.EF;
using Blog.Data.EF.Entities;

namespace Blog.Data
{
    public class PostsRepository : BaseRepository<Post>, IPostsRepository
    {
        public PostsRepository(BlogContext blogContext) : base(blogContext)
        {
        }
    }
}


using Blog.Data.Contracts;
using Blog.Data.EF;
using Blog.Data.EF.Entities;

namespace Blog.Data
{
    public class CategoriesRepository : BaseRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(BlogContext blogContext) : base(blogContext)
        {
        }
    }
}

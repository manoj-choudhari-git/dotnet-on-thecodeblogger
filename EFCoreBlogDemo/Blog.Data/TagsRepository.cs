
using Blog.Data.Contracts;
using Blog.Data.EF;
using Blog.Data.EF.Entities;

namespace Blog.Data
{
    public class TagsRepository: BaseRepository<Tag>, ITagsRepository
    {
        public TagsRepository(BlogContext blogContext) : base(blogContext)
        {
        }
    }
}

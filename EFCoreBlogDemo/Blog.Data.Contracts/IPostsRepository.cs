using Blog.Data.EF.Entities;

namespace Blog.Data.Contracts
{
    public interface IPostsRepository: IBaseRepository<Post>
    {
    }
}

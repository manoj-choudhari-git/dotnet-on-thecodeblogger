using System;
using System.Threading.Tasks;

using Blog.Business.Contracts;
using Blog.Data;
using Blog.Data.Contracts;
using Blog.Data.Contracts.Specifications;
using Blog.Data.EF.Entities;

using Microsoft.Extensions.Logging;

namespace Blog.Business
{
    public class PostsBusiness : BaseBusiness<IPostsRepository, Post>, IPostsBusiness
    {
        public PostsBusiness(IPostsRepository repository, ILogger<PostsBusiness> logger)
            : base(repository, logger)
        {

        }

        public Task<Post> GetById(int id)
        {
            var specifications = new PostRelatedDataSpecifications(id)
                                    .And(new PostsWithoutCommentsSpecification())
                                    .Or(new PostsCreatedInLastMonthSpecification());

            return Repository.GetByIdAsync(id, specifications);
        }
    }
}

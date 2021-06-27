using System;

using Blog.Business.Contracts;
using Blog.Data.Contracts;
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
    }
}

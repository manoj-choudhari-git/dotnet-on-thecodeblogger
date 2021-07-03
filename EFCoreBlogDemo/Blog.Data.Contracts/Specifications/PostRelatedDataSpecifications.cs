using System;

using Blog.Data.EF.Entities;

namespace Blog.Data.Contracts.Specifications
{
    public class PostRelatedDataSpecifications : BaseSpecifications<Post>
    {
        public PostRelatedDataSpecifications(int id) : base()
        {
            SetFilterCondition(post => post.Id == id);
            AddInclude(post => post.PostTags);
            AddInclude(post => post.PostCategories);
            AddInclude(post => post.Comments);
        }
    }

    public class PostsWithoutCommentsSpecification: BaseSpecifications<Post>
    {
        public PostsWithoutCommentsSpecification() : base()
        {
            SetFilterCondition(post => post.Comments.Count == 0);
        }
    }

    public class PostsCreatedInLastMonthSpecification : BaseSpecifications<Post>
    {
        public PostsCreatedInLastMonthSpecification() : base()
        {
            SetFilterCondition(post => post.CreatedOn >= DateTime.Now.AddMonths(-1));
        }
    }
}

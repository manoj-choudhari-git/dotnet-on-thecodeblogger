using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Data.EF.Entities;

namespace Blog.Api.Models
{
    public class PostModel : BaseModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string PostContents { get; set; }
        public List<PostTags> PostTags { get; set; }
        public List<PostCategories> PostCategories { get; set; }
        public List<Comment> Comments { get; set; }
    }
}

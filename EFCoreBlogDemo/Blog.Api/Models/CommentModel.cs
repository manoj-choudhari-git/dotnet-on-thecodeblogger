using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Data.EF.Entities;
using Blog.Data.EF;

namespace Blog.Api.Models
{
    public class CommentModel : BaseModel
    {
        public string CommentContents { get; set; }

        public string PostedBy { get; set; }

        public CommentModel Parent { get; set; }

        public PostModel ParentPost { get; set; }
    }
}

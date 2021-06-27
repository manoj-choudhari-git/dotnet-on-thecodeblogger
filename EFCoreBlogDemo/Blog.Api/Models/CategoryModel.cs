using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Api.Models
{
    public class CategoryModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
    }
}

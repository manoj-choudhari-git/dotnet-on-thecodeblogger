using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Api.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool IsPublished { get; set; }
    }
}

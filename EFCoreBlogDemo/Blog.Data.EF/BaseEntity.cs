using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.EF
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public DateTime PublishedOn { get; set; }
    }
}

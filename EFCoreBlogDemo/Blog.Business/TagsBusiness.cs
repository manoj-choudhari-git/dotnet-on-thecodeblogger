using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.Business.Contracts;
using Blog.Data.Contracts;
using Blog.Data.EF.Entities;
using Microsoft.Extensions.Logging;

namespace Blog.Business
{
    public class TagsBusiness : BaseBusiness<ITagsRepository, Tag>, ITagsBusiness
    {
        public TagsBusiness(ITagsRepository repository, ILogger<PostsBusiness> logger)
            : base(repository, logger)
        {

        }
    }
}

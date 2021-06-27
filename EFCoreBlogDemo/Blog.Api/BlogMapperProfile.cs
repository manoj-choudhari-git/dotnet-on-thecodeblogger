using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Blog.Api.Models;
using Blog.Data.EF.Entities;

namespace Blog.Api
{
    public class BlogMapperProfile : Profile
    {
        public BlogMapperProfile()
        {
            CreateMap<CategoryModel, Category>().ReverseMap();
            CreateMap<TagModel, Tag>().ReverseMap();
            CreateMap<PostModel, Post>().ReverseMap();
        }
    }
}

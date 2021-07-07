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
            CreateMap<CommentModel, Comment>().ReverseMap();
            CreateMap<PostModel, Post>()
                .ForMember(m => m.PostCategories, opt => opt.Ignore())
                .ForMember(m => m.PostTags, opt => opt.Ignore())
                .ForMember(m => m.Comments, opt => opt.Ignore())
                .ReverseMap();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using AutoMapper;

namespace WebApiAutoMapperDemo
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Source, Destination>().ReverseMap();
        }
    }
}

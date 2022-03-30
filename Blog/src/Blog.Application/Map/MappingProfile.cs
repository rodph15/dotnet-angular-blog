using AutoMapper;
using AutoMapper.Configuration;
using Blog.Application.Dtos;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Map
{
    public class MappingProfile : MapperConfigurationExpression
    {
        public MappingProfile()
        {
            CreateMap<CreatePostDto, Post>()
                .ForMember(x => x.CreatedAt, m => m.MapFrom(o => DateTimeOffset.UtcNow.ToUnixTimeSeconds()))
                .ForMember(x => x.Id, m => m.MapFrom(o => Guid.NewGuid()));

            CreateMap<Post, PostDto>();

        }
    }
}

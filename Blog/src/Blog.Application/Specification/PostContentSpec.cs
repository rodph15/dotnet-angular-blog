using Blog.Application.Dtos;
using NetDevPack.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Specification
{
    public class PostContentSpec : Specification<CreatePostDto>
    {
        public override Expression<Func<CreatePostDto, bool>> ToExpression() =>
            createPostDto => createPostDto.Content.Length <= 500;
    }
}

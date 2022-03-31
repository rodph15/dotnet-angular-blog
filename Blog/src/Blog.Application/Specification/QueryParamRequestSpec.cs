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
    public class QueryParamRequestSpec : Specification<GetPostDto>
    {
        public override Expression<Func<GetPostDto, bool>> ToExpression() =>
            getPostDto => getPostDto.Skip < getPostDto.Take;
    }
}

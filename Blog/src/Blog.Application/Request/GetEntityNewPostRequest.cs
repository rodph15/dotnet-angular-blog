using Blog.Application.Dtos;
using Blog.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Request
{
    public struct GetEntityNewPostRequest : IRequest<GetPostResponse>
    {
        public GetEntityNewPostRequest(GetEntityPostDto getEntityPostDto)
        {
            GetEntityPostDto = getEntityPostDto;
        }

        public GetEntityPostDto GetEntityPostDto { get; }
    }
}

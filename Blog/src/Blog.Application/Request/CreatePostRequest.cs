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
    public struct CreatePostRequest : IRequest<CreatePostResponse>
    {
        public CreatePostRequest(CreatePostDto createPostDto)
        {
            CreatePostDto = createPostDto;
        }

        public CreatePostDto CreatePostDto { get; }
    }
}

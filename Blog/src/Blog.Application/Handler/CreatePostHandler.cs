using AutoMapper;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Contracts;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Handler
{
    public class CreatePostHandler : IRequestHandler<CreatePostRequest, CreatePostResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatePostHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<CreatePostResponse> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            await _postRepository.CreatePost(_mapper.Map<Post>(request.CreatePostDto));

            return new CreatePostResponse("Post has been created successfuly");
        }
    }
}

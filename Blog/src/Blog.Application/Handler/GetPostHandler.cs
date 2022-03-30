using AutoMapper;
using Blog.Application.Dtos;
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
    public class GetPostHandler : IRequestHandler<GetPostRequest, GetPostResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<GetPostResponse> Handle(GetPostRequest request, CancellationToken cancellationToken)
        {
            IReadOnlyCollection<Post> posts = await _postRepository.GetPosts(request.GetPostDto.Skip, request.GetPostDto.Take);

            return new GetPostResponse(_mapper.Map<IReadOnlyCollection<PostDto>>(posts));
        }
    }
}

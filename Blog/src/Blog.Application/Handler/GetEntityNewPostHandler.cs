using AutoMapper;
using Blog.Application.Dtos;
using Blog.Application.Exceptions;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Application.Specification;
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
    public class GetEntityNewPostHandler : IRequestHandler<GetEntityNewPostRequest, GetPostResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetEntityNewPostHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<GetPostResponse> Handle(GetEntityNewPostRequest request, CancellationToken cancellationToken)
        {
            if (!await _postRepository.HasEntity(request.GetEntityPostDto.Id))
                throw new InvalidEntityException($"The entity {request.GetEntityPostDto.Id} doesnt exists");

            IReadOnlyCollection<Post> posts = await _postRepository.GetNewEntityPosts(request.GetEntityPostDto.Id);

            return new GetPostResponse(_mapper.Map<IReadOnlyCollection<PostDto>>(posts));
        }
    }
}

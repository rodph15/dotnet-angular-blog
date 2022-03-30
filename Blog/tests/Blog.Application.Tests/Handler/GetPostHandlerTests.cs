using AutoMapper;
using Blog.Application.Dtos;
using Blog.Application.Handler;
using Blog.Application.Map;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Contracts;
using Blog.Domain.Entities;
using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Blog.Application.Tests.Handler
{
    public class GetPostHandlerTests
    {
        private IMapper _mapper;
        private Mock<IPostRepository> _postRepositoryMock;

        public GetPostHandlerTests()
        {
            var mappingProfile = new MappingProfile();

            var config = new MapperConfiguration(mappingProfile);
            _mapper = new Mapper(config);

            _postRepositoryMock = new Mock<IPostRepository>();
        }

        [Fact]
        public async Task Handler_Should_Return_Success()
        {
            var handler = new GetPostHandler(_postRepositoryMock.Object, _mapper);
            _postRepositoryMock.Setup(x => x.GetPosts(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new List<Post>
            {
                new Post(),
                new Post()
            });

            var result = await handler.Handle(new GetPostRequest(new GetPostDto()), CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeOfType<GetPostResponse>();
            result.PostDtos.Should().HaveCount(2);

        }
    }
}

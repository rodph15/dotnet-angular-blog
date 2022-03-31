using AutoMapper;
using Blog.Application.Dtos;
using Blog.Application.Exceptions;
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
    public class CreatePostHandlerTests
    {
        private IMapper _mapper;
        private Mock<IPostRepository> _postRepositoryMock;

        public CreatePostHandlerTests()
        {
            var mappingProfile = new MappingProfile();

            var config = new MapperConfiguration(mappingProfile);
            _mapper = new Mapper(config);

            _postRepositoryMock = new Mock<IPostRepository>();
        }

        [Fact]
        public async Task Handler_Should_Return_Success()
        {
            var handler = new CreatePostHandler(_postRepositoryMock.Object, _mapper);
            _postRepositoryMock.Setup(x => x.CreatePost(It.IsAny<Post>()));
            _postRepositoryMock.Setup(x => x.HasEntity(It.IsAny<string>())).ReturnsAsync(true);

            var result = await handler.Handle(new CreatePostRequest(new CreatePostDto
            {
                Author = "",
                Content = ""
            }), CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().BeOfType<CreatePostResponse>();
            result.Message.Should().BeEquivalentTo("Post has been created successfuly");

        }

        [Fact]
        public async Task Handler_Should_Return_MaxContentException()
        {
            var handler = new CreatePostHandler(_postRepositoryMock.Object, _mapper);
            _postRepositoryMock.Setup(x => x.CreatePost(It.IsAny<Post>()));
            _postRepositoryMock.Setup(x => x.HasEntity(It.IsAny<string>())).ReturnsAsync(true);

            await handler.Invoking(y => y.Handle(new CreatePostRequest(new CreatePostDto
            {
                Author = "Teste",
                Content = string.Join("", Enumerable.Repeat(0, 510).Select(n => (char)new Random().Next(127)))
            }), CancellationToken.None))
            .Should()
            .ThrowAsync<MaxContentException>()
            .WithMessage("The post content must be less than 500 characteres");

        }
    }
}

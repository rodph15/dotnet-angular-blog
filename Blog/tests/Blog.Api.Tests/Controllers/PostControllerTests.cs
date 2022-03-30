using AutoMapper;
using Blog.Api.Controllers;
using Blog.Application.Dtos;
using Blog.Application.Map;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Contracts;
using Blog.Domain.Entities;
using Blog.Infrastructure.Repositories;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Blog.Api.Tests.Controllers
{
    public class PostControllerTests
    {
        private Mock<IMediator> _mediatorMock;

        public PostControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
        }

        [Fact]
        public async Task Post_should_return_Ok()
        {
            var controller = new PostController(_mediatorMock.Object);

            _mediatorMock.Setup(x => x.Send(It.IsAny<CreatePostRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreatePostResponse());

            var result = await controller.Post(new CreatePostDto());

            var contentResult = result as OkObjectResult;
            contentResult.Should().NotBeNull();
            contentResult?.StatusCode.Should().Be(200);
            contentResult?.Value.Should().BeOfType<CreatePostResponse>();

        }

        [Fact]
        public async Task Get_should_return_Ok()
        {
            var controller = new PostController(_mediatorMock.Object);

            _mediatorMock.Setup(x => x.Send(It.IsAny<GetPostRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetPostResponse());

            var result = await controller.Get(new GetPostDto());

            var contentResult = result as OkObjectResult;
            contentResult.Should().NotBeNull();
            contentResult?.StatusCode.Should().Be(200);
            contentResult?.Value.Should().BeOfType<GetPostResponse>();


        }
    }
}

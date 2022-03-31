using Blog.Application.Dtos;
using Blog.Application.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto createPostDto)
        {
            try
            {
                var request = new CreatePostRequest(createPostDto);
                var result = await _mediator.Send(request, CancellationToken.None);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPost([FromQuery] GetPostDto getPostDto)
        {
            try
            {
                var request = new GetPostRequest(getPostDto);
                var result = await _mediator.Send(request, CancellationToken.None);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEntityPost([FromQuery] GetEntityPostDto getEntityPostDto)
        {
            try
            {
                var request = new GetEntityPostRequest(getEntityPostDto);
                var result = await _mediator.Send(request, CancellationToken.None);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEntityNewPost([FromQuery] GetEntityPostDto getEntityPostDto)
        {
            try
            {
                var request = new GetEntityNewPostRequest(getEntityPostDto);
                var result = await _mediator.Send(request, CancellationToken.None);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
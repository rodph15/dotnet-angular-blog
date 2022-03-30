using Blog.Application.Dtos;
using Blog.Application.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePostDto createPostDto)
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
        public async Task<IActionResult> Get([FromQuery] GetPostDto getPostDto)
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
    }
}
using Blog.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Response
{
    public struct GetPostResponse
    {
        public GetPostResponse(IEnumerable<PostDto> postDtos)
        {
            PostDtos = postDtos;
        }

        public IEnumerable<PostDto> PostDtos { get; }
    }
}

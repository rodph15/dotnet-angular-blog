using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Response
{
    public struct CreatePostResponse
    {
        public CreatePostResponse(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}

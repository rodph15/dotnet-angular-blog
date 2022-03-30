using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Dtos
{
    public class GetPostDto
    {
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
    }
}

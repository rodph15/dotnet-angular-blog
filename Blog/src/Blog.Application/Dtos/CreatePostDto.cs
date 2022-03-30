using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Dtos
{
    public struct CreatePostDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Author { get; set; }
    }
}

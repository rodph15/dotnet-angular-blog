using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Dtos
{
    public class GetEntityPostDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Id { get; set; }
    }
}

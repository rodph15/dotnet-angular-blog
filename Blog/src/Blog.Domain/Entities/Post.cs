using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class Post
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public int CreatedAt { get; set; }
        public CommentedEntity CommentedEntity { get; set; }

    }
}

using System;
using System.Collections.Generic;
using Infrastructure.Comments.Models;

namespace Infrastructure.Posts.Models
{
    public class PostView
    {
        public Guid Id { get; set; }

        public List<CommentView> Comments { get; set; }
    }
}

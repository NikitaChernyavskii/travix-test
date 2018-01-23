using System;
using System.Collections.Generic;
using Core.Comments.Models;

namespace Core.Posts.Models
{
    public class PostView
    {
        public Guid Id { get; set; }

        public List<CommentView> Comments { get; set; }
    }
}

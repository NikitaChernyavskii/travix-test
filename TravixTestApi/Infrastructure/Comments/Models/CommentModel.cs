using System;

namespace Core.Comments.Models
{
    public class CommentModel
    {
        public string Value { get; set; }
        public Guid PostId { get; set; }
    }
}

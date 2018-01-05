using System;

namespace Infrastructure.Comments.Models
{
    public class CommentModel
    {
        public string Value { get; set; }
        public Guid PostId { get; set; }
    }
}

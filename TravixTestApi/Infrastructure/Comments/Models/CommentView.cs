using System;

namespace Infrastructure.Comments.Models
{
    public class CommentView
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public Guid PostId { get; set; }
    }
}

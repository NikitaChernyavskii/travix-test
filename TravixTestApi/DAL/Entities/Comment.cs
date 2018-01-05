using System;

namespace DAL.Entities
{
    public class Comment : IEntity
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public Guid PostId { get; set; }

        // nav property (EF)
        public Post Post { get; set; }
    }
}

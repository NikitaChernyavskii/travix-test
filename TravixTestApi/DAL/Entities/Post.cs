using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Post : IEntity
    {
        public Guid Id { get; set; }

        // nav property (EF)
        public ICollection<Comment> Comments { get; set; }
    }
}

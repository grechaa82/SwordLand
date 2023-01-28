using System;
using System.Collections.Generic;

namespace SwordLand.DataAccess.MSSQL.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
        public string Content { get; set; }
        public Comment ParentComment { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPublished { get; set; }
        public DateTime LastModified { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SwordLand.Core.Models
{
    public class Comment
    {
        public User User { get; set; }
        public Post Post { get; set; }
        public string Content { get; set; }
        public Comment ParentComment { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}

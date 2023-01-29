using System;
using System.Collections.Generic;

namespace SwordLand.Core.Models
{
    public class Post
    {
        public User User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summery { get; set; }
        public Category Category { get; set; }
        public string PostUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}

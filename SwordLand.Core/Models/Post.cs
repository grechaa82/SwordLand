using System;
using System.Collections.Generic;

namespace SwordLand.Core.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summery { get; set; }
        public string Category { get; set; }
        public string PostUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPublished { get; set; }
        public DateTime LastModified { get; set; }
    }
}

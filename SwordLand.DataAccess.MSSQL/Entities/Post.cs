using System;

namespace SwordLand.DataAccess.MSSQL.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summery { get; set; }
        public Category Category { get; set; }
        public string PostUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPublished { get; set; }
        public DateTime LastModified { get; set; }
    }
}

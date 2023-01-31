using System;
using System.Collections.Generic;

namespace SwordLand.DataAccess.MSSQL.Entities
{
    public class PostEntity
    {
        public Guid Id { get; set; }
        public UserEntity User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summery { get; set; }
        public CategoryEntity Category { get; set; }
        public string PostUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPublished { get; set; }
        public DateTime LastModified { get; set; }

        /*public ICollection<CommentEntity> Comments { get; set; }*/
    }
}

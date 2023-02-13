using System;
using System.Collections.Generic;

namespace SwordLand.DataAccess.MSSQL.Entities
{
    public class CommentEntity
    {
        public Guid Id { get; set; }
        public UserEntity User { get; set; }
        public PostEntity Post { get; set; }
        public string Content { get; set; }
        public CommentEntity ParentComment { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPublished { get; set; }
        public DateTime LastModified { get; set; }

        /*public ICollection<CommentEntity> Comments { get; set; }*/
    }
}

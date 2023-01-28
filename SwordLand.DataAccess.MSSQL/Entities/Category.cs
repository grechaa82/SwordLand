using System;
using System.Collections.Generic;

namespace SwordLand.DataAccess.MSSQL.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SwordLand.DataAccess.MSSQL.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string NameRole { get; set; }

        public ICollection<User> Users { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SwordLand.Core.Models
{
    public class Role
    {
        public string NameRole { get; set; }

        public ICollection<User> Users { get; set; }
    }
}

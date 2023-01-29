using System.Collections.Generic;

namespace SwordLand.Core.Models
{
    public class Category
    {
        public string Title { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}

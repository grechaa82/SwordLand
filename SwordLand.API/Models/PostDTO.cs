using System;
using System.Collections.Generic;

namespace SwordLand.API.Models
{
    public class PostDTO
    {
        public string User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summery { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<CommentDTO> Comments { get; set; }
    }
}

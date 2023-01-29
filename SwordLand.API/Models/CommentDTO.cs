
using System;
using System.Collections.Generic;

namespace SwordLand.API.Models
{
    public class CommentDTO
    {
        public string User { get; set; }
        public PostDTO Post { get; set; }
        public string Content { get; set; }
        public CommentDTO ParentComment { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<CommentDTO> Comments { get; set; }
    }
}

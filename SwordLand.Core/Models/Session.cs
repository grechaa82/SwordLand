using System;
using System.Collections.Generic;
using System.Text;

namespace SwordLand.Core.Models
{
    public class Session
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

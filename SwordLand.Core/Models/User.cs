using System;
using System.Collections.Generic;

namespace SwordLand.Core.Models
{
    public class User
    {
        public string NickName { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
        public string HashPassword { get; set; }
        public string UserUrl { get; set; }
        public Role Role { get; set; }
        public DateTime CreatetAt { get; set; }

        //public ICollection<MinecraftAccount> MinecraftAccounts { get; set; }
        /*public ICollection<Post> Posts { get; set; }*/
        //public ICollection<Session> Sessions { get; set; }
    }
}

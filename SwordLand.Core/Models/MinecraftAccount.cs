using System;

namespace SwordLand.Core.Models
{
    public class MinecraftAccount
    {
        public User User { get; set; }
        public string UserName { get; set; }
        public string UUID { get; set; }
        public string Email { get; set; }
        public string SkinLink { get; set; }
    }
}

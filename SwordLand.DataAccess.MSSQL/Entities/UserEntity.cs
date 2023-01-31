using System;
using System.Collections.Generic;

namespace SwordLand.DataAccess.MSSQL.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
        public string HashPassword { get; set; }
        public string Salt { get; set; }
        public string UserUrl { get; set; }
        public RoleEntity Role { get; set; }
        public DateTime CreatetAt { get; set; }

        //public ICollection<MinecraftAccountEntity> MinecraftAccounts { get; set; }
        /*public ICollection<PostEntity> Posts { get; set; }*/
        //public ICollection<SessionEntity> Sessions { get; set; }
    }
}

using System;

namespace SwordLand.DataAccess.MSSQL.Entities
{
    public class MinecraftAccountEntity
    {
        public Guid Id { get; set; }
        public UserEntity User { get; set; }
        public string UserName { get; set; }
        public string UUID { get; set; }
        public string Email { get; set; }
        public string SkinLink { get; set; }
    }
}

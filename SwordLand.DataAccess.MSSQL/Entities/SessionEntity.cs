using System;

namespace SwordLand.DataAccess.MSSQL.Entities
{
    public class SessionEntity
    {
        public Guid Id { get; set; }
        public UserEntity User { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt   { get; set; }

    }
}

using System;

namespace SwordLand.DataAccess.MSSQL.Entities
{
    public class Session
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt   { get; set; }
    }
}

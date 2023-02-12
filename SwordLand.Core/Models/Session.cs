using System;
using System.Collections.Generic;
using System.Text;

namespace SwordLand.Core.Models
{
    public class Session
    {
        public Session(
            Guid id, 
            User user, 
            string token, 
            DateTime createdAt)
        {
            Id = id;
            User = user;
            Token = token;
            CreatedAt = createdAt;
        }

        public Guid Id { get; private set; }
        public User User { get; private set; }
        public string Token { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public static Session Create(
            User user, 
            string token)
        {
            if (user is null)
            {
                throw new ArgumentNullException($"{nameof(user)} cannot be null");
            }

            if (token is null)
            {
                throw new ArgumentNullException($"{nameof(token)} cannot be null");
            }

            var session = new Session(
                Guid.NewGuid(),
                user, 
                token,
                DateTime.Now);

            return session;
        }
    }
}

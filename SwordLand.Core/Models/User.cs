using System;

namespace SwordLand.Core.Models
{
    public class User
    {
        const int MAX_NICKNAME_LENGTH = 36;
        const string DEFAULT_NAME_ROLE = "test";

        private User(
            Guid id,
            string nickName, 
            string email,
            string hashPassword, 
            string userUrl, 
            Role role, 
            DateTime createtAt,
            int rating)
        {
            Id = id;
            NickName = nickName;
            Email = email;
            Rating = rating;
            HashPassword = hashPassword;
            UserUrl = userUrl;
            Role = role;
            CreatetAt = createtAt;
        }
        public Guid Id { get; private set; }
        public string NickName { get; private set; }
        public string Email { get; private set; }
        public int Rating { get; set; }
        public string HashPassword { get; private set; }
        public string UserUrl { get; private set; }
        public Role Role { get; private set; }
        public DateTime CreatetAt { get; private set; }

        public static User Create(
            string nickName, 
            string email, 
            string hashPassword)
        {
            if (string.IsNullOrWhiteSpace(nickName))
            {
                throw new ArgumentNullException($"{nameof(nickName)} is incorrect");
            }

            if (!string.IsNullOrWhiteSpace(nickName)
                && nickName.Length >= MAX_NICKNAME_LENGTH)
            {
                throw new ArgumentException($"{nameof(nickName)} is not be more than {MAX_NICKNAME_LENGTH} chars");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException($"{nameof(email)} is incorrect");
            }

            if (string.IsNullOrWhiteSpace(hashPassword))
            {
                throw new ArgumentNullException($"{nameof(hashPassword)} is incorrect");
            }

            var userUrl = "Blogs/"+ nickName;

            var role = Role.Create(DEFAULT_NAME_ROLE);

            var user = new User(
                Guid.NewGuid(), 
                nickName, 
                email, 
                hashPassword, 
                userUrl, 
                role, 
                DateTime.Now, 
                default);

            return user;
        }
    }
}

using System;

namespace SwordLand.Core.Models
{
    public class MinecraftAccount
    {
        const int MAX_USERNAME_LENGTH = 16;
        const int UUID_LENGTH = 36;

        public MinecraftAccount(
            User user, 
            string userName, 
            string uuid, 
            string email, 
            string skinLink)
        {
            User = user;
            UserName = userName;
            UUID = uuid;
            Email = email;
            SkinLink = skinLink;
        }

        public User User { get; private set; }
        public string UserName { get; private set; }
        public string UUID { get; private set; }
        public string Email { get; private set; }
        public string SkinLink { get; private set; }

        public static MinecraftAccount Create(
            User user,
            string userName,
            string uuid,
            string email)
        {
            if (user is null)
            {
                throw new ArgumentNullException($"{nameof(user)} cannot be null");
            }

            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException($"{nameof(userName)} is incorrect");
            }

            if (!string.IsNullOrWhiteSpace(userName)
                && userName.Length >= MAX_USERNAME_LENGTH)
            {
                throw new ArgumentException($"{nameof(userName)} is not be more than {MAX_USERNAME_LENGTH} chars");
            }

            if (string.IsNullOrWhiteSpace(uuid))
            {
                throw new ArgumentNullException($"{nameof(uuid)} is incorrect");
            }

            if (!string.IsNullOrWhiteSpace(uuid)
                && uuid.Length != UUID_LENGTH)
            {
                throw new ArgumentException($"{nameof(uuid)} must be equal to {UUID_LENGTH} chars");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException($"{nameof(email)} is incorrect");
            }

            var skinLink = "img/skin/" + uuid + ".png";

            var minecraftAccount = new MinecraftAccount(
                user,
                userName,
                uuid,
                email,
                skinLink);

            return minecraftAccount;
        }
    }
}

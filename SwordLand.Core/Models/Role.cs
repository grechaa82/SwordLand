using System;

namespace SwordLand.Core.Models
{
    public class Role
    {
        const int MAX_NAMEROLE_LENGTH = 255;

        private Role(Guid id, string nameRole)
        {
            Id = id;
            NameRole = nameRole;
        }

        public Guid Id { get; private set; }
        public string NameRole { get; private set; }

        public static Role Create (string nameRole)
        {
            if (string.IsNullOrWhiteSpace(nameRole))
            {
                 throw new ArgumentNullException($"{nameof(nameRole)} is incorrect");
            }

            if (!string.IsNullOrWhiteSpace(nameRole)
                && nameRole.Length >= MAX_NAMEROLE_LENGTH)
            {
                throw new ArgumentException($"{nameof(nameRole)} is not be more than {MAX_NAMEROLE_LENGTH} chars");
            }

            var role = new Role(
                Guid.NewGuid(),
                nameRole);

            return role;
        }
    }
}

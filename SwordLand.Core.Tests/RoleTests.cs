using SwordLand.Core.Models;
using System;
using Xunit;

namespace SwordLand.Core.Tests
{
    public class RoleTests
    {
        #region IsValid

        [Fact]
        public void Create_IsValid_ShoudReturnRole()
        {
            // Arrange
            string nameRole = "test nameRole";

            // Act
            var role = Role.Create(nameRole);

            // Assert
            Assert.NotNull(role);
            Assert.Equal(nameRole, role.NameRole);
        }

        #endregion

        [Fact]
        public void Create_WhenNameRoleNull_ArgumentNullException()
        {
            // Arrange
            string nameRole = null;
            var exceptionMessage = "Value cannot be null. (Parameter 'nameRole is incorrect')";

            // Act
            Action roleAction = () => Role.Create(nameRole);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(roleAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenNameRoleWhiteSpace_ArgumentNullException()
        {
            // Arrange
            var nameRole = "  ";
            var exceptionMessage = "Value cannot be null. (Parameter 'nameRole is incorrect')";

            // Act
            Action roleAction = () => Role.Create(nameRole);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(roleAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenNameRoleIsMore255Chars_ArgumentException()
        {
            // Arrange
            var nameRole = "This string has more than 255 characters. " +
                "This string has more than 255 characters. " +
                "This string has more than 255 characters. " +
                "This string has more than 255 characters. " +
                "This string has more than 255 characters. " +
                "This string has more than 255 characters. " +
                "This string has more than 255 characters.";
            var exceptionMessage = "nameRole is not be more than 255 chars";

            // Act
            Action roleAction = () => Role.Create(nameRole);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(roleAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }
    }
}

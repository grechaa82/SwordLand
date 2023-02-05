using SwordLand.Core.Models;
using System;
using Xunit;

namespace SwordLand.Core.Tests
{
    public class MinecraftAccountTests
    {
        private User _user = User.Create(
            "nickName",
            "email@email.com",
            "ee26b0dd4af7e749aa1a8ee3c10ae9923f618980772e473f8819a5d4940e0db27ac185f8a0e1d5f84f88bc887fd67b143732c304cc5fa9ad8e6f57f50028a8ff");
        private string _email = "email@email.com";
        private string _userName = "Test UserName";
        private string _UUID = "d21c12b8-a214-11ed-a8fc-0242ac120002";

        #region IsValid

        [Fact]
        public void Create_IsValid_ShoudReturnMinecraftAccount()
        {
            // Arrange

            // Act
            var minecraftAccount = MinecraftAccount.Create(
                _user, 
                _userName,
                _UUID, 
                _email);

            // Assert
            Assert.NotNull(minecraftAccount);
            Assert.Equal(_user, minecraftAccount.User);
            Assert.Equal(_userName, minecraftAccount.UserName);
            Assert.Equal(_UUID, minecraftAccount.UUID);
            Assert.Equal(_email, minecraftAccount.Email);
        }

        #endregion

        #region CheckUserName

        [Fact]
        public void Create_WhenUserNameNull_ArgumentNullException()
        {
            // Arrange
            string userName = null;
            var exceptionMessage = "Value cannot be null. (Parameter 'userName is incorrect')";

            // Act
            Action minecraftAccountAction = () => MinecraftAccount.Create(
                _user,
                userName,
                _UUID,
                _email);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(minecraftAccountAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenUserNameWhiteSpace_ArgumentNullException()
        {
            // Arrange
            var userName = "  ";
            var exceptionMessage = "Value cannot be null. (Parameter 'userName is incorrect')";

            // Act
            Action minecraftAccountAction = () => MinecraftAccount.Create(
                _user,
                userName,
                _UUID,
                _email);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(minecraftAccountAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenUserNameIsMore16Сhars_ArgumentException()
        {
            // Arrange
            var userName = "This string has more than 16 characters";
            var exceptionMessage = "userName is not be more than 16 chars";

            // Act
            Action minecraftAccountAction = () => MinecraftAccount.Create(
                _user,
                userName,
                _UUID,
                _email);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(minecraftAccountAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        #endregion

        #region CheckUUID

        [Fact]
        public void Create_WhenUUIDNull_ArgumentNullException()
        {
            // Arrange
            string UUID = null;
            var exceptionMessage = "Value cannot be null. (Parameter 'uuid is incorrect')";

            // Act
            Action minecraftAccountAction = () => MinecraftAccount.Create(
                _user,
                _userName,
                UUID,
                _email);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(minecraftAccountAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenUUIDWhiteSpace_ArgumentNullException()
        {
            // Arrange
            var UUID = "  ";
            var exceptionMessage = "Value cannot be null. (Parameter 'uuid is incorrect')";

            // Act
            Action minecraftAccountAction = () => MinecraftAccount.Create(
                _user,
                _userName,
                UUID,
                _email);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(minecraftAccountAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenUUIDIsNotEqual36Сhars_ArgumentException()
        {
            // Arrange
            var UUID = "testUUID";
            var exceptionMessage = "uuid must be equal to 36 chars";

            // Act
            Action minecraftAccountAction = () => MinecraftAccount.Create(
                _user,
                _userName,
                UUID,
                _email);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(minecraftAccountAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        #endregion

        #region CheckEmail

        [Fact]
        public void Create_WhenEmailNull_ArgumentNullException()
        {
            // Arrange
            string email = null;
            var exceptionMessage = "Value cannot be null. (Parameter 'email is incorrect')";

            // Act
            Action minecraftAccountAction = () => MinecraftAccount.Create(
                _user,
                _userName,
                _UUID,
                email);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(minecraftAccountAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenEmailWhiteSpace_ArgumentNullException()
        {
            // Arrange
            var email = "  ";
            var exceptionMessage = "Value cannot be null. (Parameter 'email is incorrect')";

            // Act
            Action minecraftAccountAction = () => MinecraftAccount.Create(
                _user,
                _userName,
                _UUID,
                email);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(minecraftAccountAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        #endregion
    }
}

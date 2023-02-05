using SwordLand.Core.Models;
using System;
using Xunit;

namespace SwordLand.Core.Tests
{
    public class UserTests
    {
        private string _nickName = "nickName";
        private string _email = "email@email.com";
        private string _hashPassword = "ee26b0dd4af7e749aa1a8ee3c10ae9923f618980772e473f8819a5d4940e0db27ac185f8a0e1d5f84f88bc887fd67b143732c304cc5fa9ad8e6f57f50028a8ff";

        #region IsValid

        [Fact]
        public void Create_IsValid_ShoudReturnUser()
        {
            // Arrange

            // Act
            var user = User.Create(
                _nickName,
                _email,
                _hashPassword);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(_nickName, user.NickName);
            Assert.Equal(_email, user.Email);
            Assert.Equal(_hashPassword, user.HashPassword);
        }

        #endregion

        #region CheckNickName

        [Fact]
        public void Create_WhenNickNameNull_ArgumentNullException()
        {
            // Arrange
            string nickName = null;
            var exceptionMessage = "Value cannot be null. (Parameter 'nickName is incorrect')";

            // Act
            Action userAction = () => User.Create(
                nickName, 
                _email, 
                _hashPassword);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(userAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenNickNameWhiteSpace_ArgumentNullException()
        {
            // Arrange
            var nickName = "  ";
            var exceptionMessage = "Value cannot be null. (Parameter 'nickName is incorrect')";

            // Act
            Action userAction = () => User.Create(
                nickName,
                _email,
                _hashPassword);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(userAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenNickNameIsMore36Ñhars_ArgumentException()
        {
            // Arrange
            var nickName = "This string has more than 36 characters";
            var exceptionMessage = "nickName is not be more than 36 chars";

            // Act
            Action userAction = () => User.Create(
                nickName,
                _email,
                _hashPassword);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(userAction);
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
            Action userAction = () => User.Create(
                _nickName,
                email,
                _hashPassword);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(userAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenEmailWhiteSpace_ArgumentNullException()
        {
            // Arrange
            var email = "  ";
            var exceptionMessage = "Value cannot be null. (Parameter 'email is incorrect')";

            // Act
            Action userAction = () => User.Create(
                _nickName,
                email,
                _hashPassword);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(userAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        #endregion

        #region HashPassword

        [Fact]
        public void Create_WhenHashPasswordNull_ArgumentNullException()
        {
            // Arrange
            string hashPassword = null;
            var exceptionMessage = "Value cannot be null. (Parameter 'hashPassword is incorrect')";

            // Act
            Action userAction = () => User.Create(
                _nickName,
                _email,
                hashPassword);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(userAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenHashPasswordWhiteSpace_ArgumentNullException()
        {
            // Arrange
            var hashPassword = "  ";
            var exceptionMessage = "Value cannot be null. (Parameter 'hashPassword is incorrect')";

            // Act
            Action userAction = () => User.Create(
                _nickName,
                _email,
                hashPassword);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(userAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        #endregion
    }
}

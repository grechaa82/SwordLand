using SwordLand.Core.Models;
using System;
using Xunit;

namespace SwordLand.Core.Tests
{
    public class CommentTests
    {
        private static User _user = User.Create(
            "nickName",
            "email@email.com",
            "ee26b0dd4af7e749aa1a8ee3c10ae9923f618980772e473f8819a5d4940e0db27ac185f8a0e1d5f84f88bc887fd67b143732c304cc5fa9ad8e6f57f50028a8ff");
        private static Guid _id = Guid.NewGuid();
        private static Category _category = Category.Create("category");
        private static DateTime _date = DateTime.Now;
        private static string _text = Guid.NewGuid().ToString();
        private static Post _post = Post.Create(
                _id,
                _user,
                _text,
                _text,
                _text,
                _category,
                _date,
                _date,
                default);
        private static Comment _parentComment = Comment.Create(
            _user, 
            _post,
            _text,
            null);

        #region IsValid

        [Fact]
        public void Create_IsValid_ShoudReturnComment()
        {
            // Arrange

            // Act
            var comment = Comment.Create(
                _user,
                _post,
                _text,
                _parentComment);

            // Assert
            Assert.NotNull(comment);
            Assert.Equal(_user, comment.User);
            Assert.Equal(_post, comment.Post);
            Assert.Equal(_text, comment.Content);
            Assert.Equal(_parentComment, comment.ParentComment);
        }

        #endregion

        #region CheckUser

        [Fact]
        public void Create_WhenUserNull_ArgumentNullException()
        {
            // Arrange
            User user = null;
            var exceptionMessage = "Value cannot be null. (Parameter 'user cannot be null')";

            // Act
            Action commentAction = () => Comment.Create(
                user,
                _post,
                _text,
                _parentComment);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(commentAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        #endregion

        #region CheckPost

        [Fact]
        public void Create_WhenPostNull_ArgumentNullException()
        {
            // Arrange
            Post post = null;
            var exceptionMessage = "Value cannot be null. (Parameter 'post cannot be null')";

            // Act
            Action commentAction = () => Comment.Create(
                _user,
                post,
                _text,
                _parentComment);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(commentAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        #endregion

        #region CheckContent

        [Fact]
        public void Create_WhenContentNull_ArgumentNullException()
        {
            // Arrange
            string content = null;
            var exceptionMessage = "Value cannot be null. (Parameter 'content is incorrect')";

            // Act
            Action commentAction = () => Comment.Create(
                _user,
                _post,
                content,
                _parentComment);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(commentAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenContentWhiteSpace_ArgumentNullException()
        {
            // Arrange
            var content = "  ";
            var exceptionMessage = "Value cannot be null. (Parameter 'content is incorrect')";

            // Act
            Action commentAction = () => Comment.Create(
                _user,
                _post,
                content,
                _parentComment);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(commentAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        #endregion
    }
}

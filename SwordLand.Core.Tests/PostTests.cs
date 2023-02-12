using SwordLand.Core.Models;
using System;
using Xunit;

namespace SwordLand.Core.Tests
{
    public class PostTests
    {
        private Guid _id = Guid.NewGuid();
        private User _user = User.Create(
            "nickName", 
            "email@email.com", 
            "ee26b0dd4af7e749aa1a8ee3c10ae9923f618980772e473f8819a5d4940e0db27ac185f8a0e1d5f84f88bc887fd67b143732c304cc5fa9ad8e6f57f50028a8ff");
        private string _text = Guid.NewGuid().ToString();
        private Category _category = Category.Create("category");
        private DateTime _date = DateTime.Now;

        #region IsValid

        [Fact]
        public void Create_IsValid_ShoudReturnPost()
        {
            // Arrange

            // Act
            var post = Post.Create(
                _id,
                _user,
                _text,
                _text,
                _text,
                _category,
                _date,
                _date,
                true);

            // Assert
            Assert.NotNull(post);
            Assert.Equal(_id, post.Id);
            Assert.Equal(_user, post.User);
            Assert.Equal(_text, post.Title);
            Assert.Equal(_text, post.Content);
            Assert.Equal(_text, post.Summery);
            Assert.Equal(_category, post.Category);
            Assert.Equal(_date, post.CreatedAt);
            Assert.True(post.IsPublished);
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
            Action postAction = () => Post.Create(
                _id,
                user,
                _text,
                _text,
                _text,
                _category,
                _date,
                _date,
                default);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(postAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        #endregion

        #region CheckTitle

        [Fact]
        public void Create_WhenTitleNull_ArgumentNullException()
        {
            // Arrange
            string title = null;
            var exceptionMessage = "Value cannot be null. (Parameter 'title is incorrect')";

            // Act
            Action postAction = () => Post.Create(
                _id,
                _user,
                title,
                _text,
                _text,
                _category,
                _date,
                _date,
                default);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(postAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenTitleWhiteSpace_ArgumentNullException()
        {
            // Arrange
            var title = "  ";
            var exceptionMessage = "Value cannot be null. (Parameter 'title is incorrect')";

            // Act
            Action postAction = () => Post.Create(
                _id,
                _user,
                title,
                _text,
                _text,
                _category,
                _date,
                _date,
                default);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(postAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenTitleIsMore255Chars_ArgumentException()
        {
            // Arrange
            var title = "This string has more than 255 characters. " +
                "This string has more than 255 characters. " +
                "This string has more than 255 characters. " +
                "This string has more than 255 characters. " +
                "This string has more than 255 characters. " +
                "This string has more than 255 characters. " +
                "This string has more than 255 characters.";
            var exceptionMessage = "title is not be more than 255 chars";

            // Act
            Action postAction = () => Post.Create(
                _id,
                _user,
                title,
                _text,
                _text,
                _category,
                _date,
                _date,
                default);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(postAction);
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
            Action postAction = () => Post.Create(
                _id,
                _user,
                _text,
                content,
                _text,
                _category,
                _date,
                _date,
                default);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(postAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenContentWhiteSpace_ArgumentNullException()
        {
            // Arrange
            var content = "  ";
            var exceptionMessage = "Value cannot be null. (Parameter 'content is incorrect')";

            // Act
            Action postAction = () => Post.Create(
                _id,
                _user,
                _text,
                content,
                _text,
                _category,
                _date,
                _date,
                default);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(postAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        #endregion

        #region CheckSummery

        [Fact]
        public void Create_WhenSummeryNull_ArgumentNullException()
        {
            // Arrange
            string summery = null;
            var exceptionMessage = "Value cannot be null. (Parameter 'summery is incorrect')";

            // Act
            Action postAction = () => Post.Create(
                _id,
                _user,
                _text,
                _text,
                summery,
                _category,
                _date,
                _date,
                default);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(postAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenSummeryWhiteSpace_ArgumentNullException()
        {
            // Arrange
            var summery = "  ";
            var exceptionMessage = "Value cannot be null. (Parameter 'summery is incorrect')";

            // Act
            Action postAction = () => Post.Create(
                _id,
                _user,
                _text,
                _text,
                summery,
                _category,
                _date,
                _date,
                default);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(postAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenSummeryIsMore255Chars_ArgumentException()
        {
            // Arrange
            var summery = "This string has more than 255 characters. " +
                "This string has more than 255 characters. " +
                "This string has more than 255 characters. " +
                "This string has more than 255 characters. " +
                "This string has more than 255 characters. " +
                "This string has more than 255 characters. " +
                "This string has more than 255 characters. " +
                "This string has more than 255 characters.";
            var exceptionMessage = "summery is not be more than 255 chars";

            // Act
            Action postAction = () => Post.Create(
                _id,
                _user,
                _text,
                _text,
                summery,
                _category,
                _date,
                _date,
                default);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(postAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        #endregion

        #region CheckCategory

        [Fact]
        public void Create_WhenCategoryNull_ArgumentNullException()
        {
            // Arrange
            Category category = null;
            var exceptionMessage = "Value cannot be null. (Parameter 'category cannot be null')";

            // Act
            Action postAction = () => Post.Create(
                _id,
                _user,
                _text,
                _text,
                _text,
                category,
                _date,
                _date,
                default);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(postAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        #endregion
    }
}

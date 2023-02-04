using SwordLand.Core.Models;
using System;
using Xunit;

namespace SwordLand.Core.Tests
{
    public class CategoryTests
    {
        #region IsValid

        [Fact]
        public void Create_IsValid_ShoudReturnCategory()
        {
            // Arrange
            string title = "test title";

            // Act
            var category = Category.Create(title);

            // Assert
            Assert.NotNull(category);
            Assert.Equal(title, category.Title);
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
            Action categoryAction = () => Category.Create(title);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(categoryAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenTitleWhiteSpace_ArgumentNullException()
        {
            // Arrange
            var title = "  ";
            var exceptionMessage = "Value cannot be null. (Parameter 'title is incorrect')";

            // Act
            Action categoryAction = () => Category.Create(title);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(categoryAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void Create_WhenTitleIsMore255Chars_ArgumentException()
        {
            // Arrange
            var title = "This string has more than 36 characters.";
            var exceptionMessage = "title is not be more than 36 chars";

            // Act
            Action categoryAction = () => Category.Create(title);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(categoryAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        #endregion
    }
}

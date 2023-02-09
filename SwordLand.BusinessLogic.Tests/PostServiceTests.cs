using AutoFixture;
using Moq;
using SwordLand.BusinessLogic.Services;
using SwordLand.Core.Interfaces.Repository;
using SwordLand.Core.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SwordLand.BusinessLogic.Tests
{
    public class PostServiceTests
    {
        private readonly PostService _postService;
        private readonly Mock<IPostRepository> _postRepositoryMock = new Mock<IPostRepository>();
        private Fixture _fixture = new Fixture();

        public PostServiceTests()
        {
            _postService = new PostService(_postRepositoryMock.Object);


        }

        [Fact]
        public void Get__ShouldReturnArrayPosts()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public void GetById_WhenPostExists_ShouldReturnPost()
        {
            // Arrange
            _fixture.Customizations.Add(
                new StringGenerator(() =>
                    Guid.NewGuid()
                    .ToString()
                    .Substring(0, 10)));
            var postDto = _fixture.Create<Post>();
            var postId = postDto.Id;

            _postRepositoryMock.Setup(x => x.GetById(postId.ToString()))
                .Returns(postDto);

            // Act
            var post = _postService.GetById(postId.ToString());

            // Assert
            Assert.NotNull(post.Item1);
            Assert.Equal(postId, post.Item1.Id);
        }

        [Fact]
        public void GetById_WhenPostDoesNotExist_ArgumentNullException()
        {
            // Arrange
            var exceptionMessage = "Value cannot be null. (Parameter 'postId is incorrect')";

            // Act
            Action postAction = () =>_postService.GetById(Guid.NewGuid().ToString());

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentNullException>(postAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }
    }
}

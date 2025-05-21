using Xunit;
using Moq;
using MyApp.Services;
using MyApp.Models;
using System.Collections.Generic;

namespace MyApp.Tests.Services
{
    public class ExampleServiceTests
    {
        private readonly Mock<IExampleRepository> _mockRepository;
        private readonly ExampleService _exampleService;

        public ExampleServiceTests()
        {
            _mockRepository = new Mock<IExampleRepository>();
            _exampleService = new ExampleService(_mockRepository.Object);
        }

        [Fact]
        public void GetExampleItems_ShouldReturnItems_WhenRepositoryReturnsItems()
        {
            // Arrange
            var exampleItems = new List<ExampleModel>
            {
                new ExampleModel { Id = 1, Name = "Item 1" },
                new ExampleModel { Id = 2, Name = "Item 2" }
            };
            _mockRepository.Setup(repo => repo.GetAll()).Returns(exampleItems);

            // Act
            var result = _exampleService.GetExampleItems();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Item 1", result[0].Name);
        }

        [Fact]
        public void GetExampleItems_ShouldReturnEmpty_WhenRepositoryReturnsEmpty()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetAll()).Returns(new List<ExampleModel>());

            // Act
            var result = _exampleService.GetExampleItems();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void AddExampleItem_ShouldAddItem_WhenValidItemIsProvided()
        {
            // Arrange
            var newItem = new ExampleModel { Id = 3, Name = "New Item" };
            _mockRepository.Setup(repo => repo.Add(newItem)).Returns(true);

            // Act
            var result = _exampleService.AddExampleItem(newItem);

            // Assert
            Assert.True(result);
            _mockRepository.Verify(repo => repo.Add(newItem), Times.Once);
        }

        [Fact]
        public void AddExampleItem_ShouldThrowException_WhenInvalidItemIsProvided()
        {
            // Arrange
            ExampleModel invalidItem = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _exampleService.AddExampleItem(invalidItem));
        }
    }
}
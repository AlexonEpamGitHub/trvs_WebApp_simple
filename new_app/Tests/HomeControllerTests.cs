using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using new_app.Controllers;
using new_app.Models.ViewModels;

namespace new_app.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_Returns_ViewResult_With_Correct_ViewModel()
        {
            // Arrange
            var mockDbContext = new Mock<IApplicationDbContext>();
            var controller = new HomeController(mockDbContext.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<HomeViewModel>(result?.Model);
        }

        [Fact]
        public void Index_Returns_ErrorView_When_Exception_Is_Thrown()
        {
            // Arrange
            var mockDbContext = new Mock<IApplicationDbContext>();
            mockDbContext.Setup(db => db.SomeAction()).Throws(new Exception("Database error"));

            var controller = new HomeController(mockDbContext.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Error", result?.ViewName);
        }
    }
}
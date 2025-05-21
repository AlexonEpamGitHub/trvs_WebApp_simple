using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using new_app.Controllers;

namespace new_app.Tests
{
    public class AboutControllerTests
    {
        private readonly AboutController _controller;
        private readonly Mock<ILogger<AboutController>> _loggerMock;

        public AboutControllerTests()
        {
            // Arrange
            _loggerMock = new Mock<ILogger<AboutController>>();
            _controller = new AboutController(_loggerMock.Object);
        }

        [Fact]
        public void About_Returns_ViewResult()
        {
            // Act
            var result = _controller.About();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("About", viewResult.ViewName);
        }

        [Fact]
        public void About_Returns_ViewResult_With_Correct_Model()
        {
            // Act
            var result = _controller.About();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult.Model);
        }

        [Fact]
        public void About_Logs_Information()
        {
            // Act
            _controller.About();

            // Assert
            _loggerMock.Verify(
                logger => logger.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.IsAny<object>(),
                    It.IsAny<Exception>(),
                    (Func<object, Exception, string>)It.IsAny<object>()
                ),
                Times.Once
            );
        }
    }
}
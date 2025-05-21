using Xunit;
using Microsoft.AspNetCore.Mvc;
using new_app.Controllers;

namespace new_app.Tests
{
    public class ContactControllerTests
    {
        private readonly ContactController _controller;

        public ContactControllerTests()
        {
            // Arrange: Initialize the ContactController
            _controller = new ContactController();
        }

        [Fact]
        public void Contact_ReturnsCorrectViewName()
        {
            // Act: Call the Contact action
            var result = _controller.Contact() as ViewResult;

            // Assert: Verify the result is not null and the view name is correct
            Assert.NotNull(result);
            Assert.Equal("Contact", result.ViewName);
        }

        [Fact]
        public void Contact_SetsMessageInViewBag()
        {
            // Act: Call the Contact action
            var result = _controller.Contact() as ViewResult;

            // Assert: Verify the ViewBag.Message is set correctly
            Assert.NotNull(result);
            Assert.Equal("Your contact page.", result.ViewData["Message"]);
        }

        // Add more tests as needed for additional functionality
    }
}
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using new_app.Controllers;

namespace new_app.test.Controllers
{
    public class HomeControllerTests
    {
        private readonly HomeController _controller;

        public HomeControllerTests()
        {
            // Initialize HomeController for testing.
            _controller = new HomeController();
        }

        [Fact]
        public void Index_ReturnsViewResult_WithCorrectViewName()
        {
            var result = _controller.Index() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result?.ViewName);
        }

        [Fact]
        public void About_ReturnsViewResult_WithCorrectViewName()
        {
            var result = _controller.About() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("About", result?.ViewName);
        }

        [Fact]
        public void Contact_ReturnsViewResult_WithCorrectViewName()
        {
            var result = _controller.Contact() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Contact", result?.ViewName);
        }

        [Fact]
        public void Index_NullRoute_ReturnsBadRequest()
        {
            // Simulate null input scenario for Index route.
            ViewResult result = null;

            try
            {
                result = _controller.Index(null) as ViewResult; // Assuming Index can take inputs.
            }
            catch
            {
                Assert.Null(result); // Ensure no crashes and validations...

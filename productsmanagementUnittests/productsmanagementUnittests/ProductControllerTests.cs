using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductManagement.Controllers;
using ProductManagement.Services;

namespace ProductManagement.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTests
    {
        private ProductsController _controller;
        private Mock<IProductService> _mockProductService;

        [TestInitialize]
        public void Setup()
        {
            _mockProductService = new Mock<IProductService>();
            _controller = new ProductsController(_mockProductService.Object);
        }

        [TestMethod]
        public async Task DeleteProduct_ReturnsNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            int productId = 1;
            _mockProductService.Setup(service => service.DeleteProductAsync(productId)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteProduct(productId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task DeleteProduct_ReturnsNoContent_WhenProductIsDeleted()
        {
            // Arrange
            int productId = 1;
            _mockProductService.Setup(service => service.DeleteProductAsync(productId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteProduct(productId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
    }
}

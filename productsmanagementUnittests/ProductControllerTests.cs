using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement.Controllers;
using ProductManagement.RequestModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTests
    {
        private ProductsController _controller;
        private ApplicationDbContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _controller = new ProductsController(_context);
        }

        [TestMethod]
        public async Task CreateProduct_ShouldReturnCreatedResult()
        {
            var productRequest = new ProductRequestModel
            {
                Name = "Test Product",
                Description = "Test Description",
                Price = 10.0m,
                Stock = 100
            };

            var result = await _controller.CreateProduct(productRequest) as CreatedAtActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(201, result.StatusCode);
        }

        [TestMethod]
        public async Task GetAllProducts_ShouldReturnListOfProducts()
        {
            await _context.Products.AddAsync(new Product { Name = "Product 1", Price = 10.0m, Stock = 100 });
            await _context.SaveChangesAsync();

            var result = await _controller.GetAllProducts() as ActionResult<IEnumerable<Product>>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Value, typeof(List<Product>));
        }

        [TestMethod]
        public async Task GetProductById_ShouldReturnNotFound_WhenProductDoesNotExist()
        {
            var result = await _controller.GetProductById(999) as NotFoundResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public async Task UpdateProduct_ShouldReturnNoContent_WhenProductIsUpdated()
        {
            var product = new Product { Name = "Product 1", Price = 10.0m, Stock = 100 };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var updatedProduct = new Product
            {
                Name = "Updated Product",
                Price = 15.0m,
                Stock = 50
            };

            var result = await _controller.UpdateProduct(product.Id, updatedProduct) as NoContentResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(204, result.StatusCode);
        }

        [TestMethod]
        public async Task DeleteProduct_ShouldReturnNoContent_WhenProductIsDeleted()
        {
            var product = new Product { Name = "Product 1", Price = 10.0m, Stock = 100 };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var result = await _controller.DeleteProduct(product.Id) as NoContentResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(204, result.StatusCode);
        }
    }
}

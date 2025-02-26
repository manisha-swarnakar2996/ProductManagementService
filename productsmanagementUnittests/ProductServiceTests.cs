using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductManagement.RequestModels;
using ProductManagement.Services;

namespace ProductManagement.Tests
{
    [TestClass]
    public class ProductServiceTests
    {
        private ProductService _productService;
        private Mock<DbSet<Product>> _mockSet;
        private Mock<ApplicationDbContext> _mockContext;

        [TestInitialize]
        public void Initialize()
        {
            _mockSet = new Mock<DbSet<Product>>();
            _mockContext = new Mock<ApplicationDbContext>();
            _mockContext.Setup(m => m.Products).Returns(_mockSet.Object);
            _productService = new ProductService(_mockContext.Object);
        }

        [TestMethod]
        public async Task CreateProduct_ShouldAddProduct()
        {
            var productRequestModel = new ProductRequestModel
            {
                Name = "Test Product",
                Description = "Test Description",
                Price = 10.0m,
                Stock = 100
            };

            var product = await _productService.CreateProduct(productRequestModel);

            _mockSet.Verify(m => m.Add(It.IsAny<Product>()), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
            Assert.AreEqual(productRequestModel.Name, product.Name);
        }

        [TestMethod]
        public async Task GetAllProducts_ShouldReturnProducts()
        {
            var products = new List<Product>
            {
                new Product { Name = "Product 1" },
                new Product { Name = "Product 2" }
            };

            _mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.AsQueryable().Provider);
            _mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.AsQueryable().Expression);
            _mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.AsQueryable().ElementType);
            _mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var result = await _productService.GetAllProducts();

            Assert.AreEqual(2, result.Count());
        }
    }
}

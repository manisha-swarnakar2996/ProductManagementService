using ProductManagement.Models;
using ProductManagement.RequestModels;
using Microsoft.EntityFrameworkCore;
using ProductManagementApi.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProductAsync(ProductRequestModel productRequestModel)
        {
            var product = new Product
            {
                Name = string.Empty,
                Price = 0,
                Stock =0,
                Description = string.Empty, // Assigning to string.Empty
                UniqueNumber = string.Empty,
            };
            var productdb = MapToProductDbModel(product);
            _context.Products.Add(productdb);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products.Cast<Product>();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDbModel = await _context.Products.FindAsync(id);
            if (productDbModel == null) return null;

            // Assuming a mapping method exists to convert ProductDbModel to Product
            return MapToProduct(productDbModel);
        }

        private Product MapToProduct(ProductDbModel productDbModel)
        {
            return new Product
            {
                Id = productDbModel.Id,
                Name = productDbModel.Name,
                Price = productDbModel.Price,
                Stock = productDbModel.Stock
            };
        }

        public async Task<bool> UpdateProductAsync(int id, Product updatedProduct)
        {
            if (id != updatedProduct.Id) return false;

            _context.Entry(updatedProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> DecrementStockAsync(int id, int quantity)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            if (product.Stock < quantity) return false;

            product.Stock -= quantity;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> AddToStockAsync(int id, int quantity)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            product.Stock += quantity;
            await _context.SaveChangesAsync();
            return true;
        }
        private ProductDbModel MapToProductDbModel(Product product)
        {
            return new ProductDbModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    }
}

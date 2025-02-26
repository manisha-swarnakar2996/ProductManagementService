using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.RequestModels;

namespace ProductManagement.Services
{
	public class ProductService
	{
		private readonly ApplicationDbContext _context;

		public ProductService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Product> CreateProduct(ProductRequestModel productRequestModel)
		{
			var product = new Product
			{
				Name = productRequestModel.Name,
				Description = productRequestModel.Description,
				Price = productRequestModel.Price,
				Stock = productRequestModel.Stock
			};

			_context.Products.Add(product);
			await _context.SaveChangesAsync();
			return product;
		}

		public async Task<IEnumerable<Product>> GetAllProducts()
		{
			return await _context.Products.ToListAsync();
		}

		public async Task<Product> GetProductById(int id)
		{
			return await _context.Products.FindAsync(id);
		}

		public async Task UpdateProduct(int id, Product updatedProduct)
		{
			var product = await _context.Products.FindAsync(id);
			if (product != null)
			{
				product.Name = updatedProduct.Name;
				product.Description = updatedProduct.Description;
				product.Price = updatedProduct.Price;
				product.Stock = updatedProduct.Stock;

				await _context.SaveChangesAsync();
			}
		}

		public async Task DeleteProduct(int id)
		{
			var product = await _context.Products.FindAsync(id);
			if (product != null)
			{
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
			}
		}

		public async Task DecrementStock(int id, int quantity)
		{
			var product = await _context.Products.FindAsync(id);
			if (product != null && product.Stock >= quantity)
			{
				product.Stock -= quantity;
				await _context.SaveChangesAsync();
			}
		}

		public async Task AddToStock(int id, int quantity)
		{
			var product = await _context.Products.FindAsync(id);
			if (product != null)
			{
				product.Stock += quantity;
				await _context.SaveChangesAsync();
			}
		}
	}
}
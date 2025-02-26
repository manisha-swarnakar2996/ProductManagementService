using ProductManagement.Models;
using ProductManagement.RequestModels;

namespace ProductManagement.Services
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(ProductRequestModel productRequestModel);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<bool> UpdateProductAsync(int id, Product updatedProduct);
        Task<bool> DeleteProductAsync(int id);
        Task<bool?> DecrementStockAsync(int id, int quantity);
        Task<bool?> AddToStockAsync(int id, int quantity);
    }
}
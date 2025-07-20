using System.Collections.Generic;
using System.Threading.Tasks;
using MvcWeb.Dtos;
using MvcWeb.Models;

namespace MvcWeb.Services
{
    public interface IProductService
    {
        Task<ProductPageModel> GetAllProductsAsync(string? searchString);
        Task<Product?> GetProductDetailsAsync(int id);
        Task<bool> CreateProductAsync(Product product);
        Task<Product?> GetProductForEditAsync(int id);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}
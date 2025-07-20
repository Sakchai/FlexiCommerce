using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MvcWeb.Data;
using MvcWeb.Dtos;
using MvcWeb.Models;
using MvcWeb.Mapping;

namespace MvcWeb.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<ProductService> _logger;

        public ProductService(ApplicationDbContext db, ILogger<ProductService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<ProductPageModel> GetAllProductsAsync(string? searchString)
        {
            try
            {
                searchString = searchString?.ToLower();
                var products = await _db.Products
                    .AsNoTracking()
                    .Include(p => p.Category)
                    .Where(p => string.IsNullOrEmpty(searchString) ||
                        p.Name.ToLower().Contains(searchString) ||
                        p.Brand.ToLower().Contains(searchString) ||
                        (p.Category != null && p.Category.Name.ToLower().Contains(searchString)))
                    .Select(p => p.ToDto())
                    .ToListAsync();
                return new ProductPageModel
                {
                    Products = products
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching products with search string '{SearchString}'", searchString);
                return new ProductPageModel
                {
                    Products = Enumerable.Empty<ProductDto>().ToList()
                };
            }
        }

        public async Task<Product?> GetProductDetailsAsync(int id)
        {
            try
            {
                return await _db.Products
                    .AsNoTracking()
                    .Include(p => p.Category)
                    .Include(p => p.Reviews)
                    .FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching product with ID {ProductId}", id);
                return null;
            }
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            try
            {
                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product with name '{ProductName}'", product.Name);
                return false;
            }
        }

        public async Task<Product?> GetProductForEditAsync(int id)
        {
            return await _db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            try
            {
                _db.Products.Update(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product with ID {ProductId}", product.Id);
                return false;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var product = await _db.Products.FindAsync(id);
                if (product == null) return false;

                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting product with ID {ProductId}", id);
                return false;
            }
        }
    }
}

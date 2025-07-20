using System.Threading.Tasks;
using MvcWeb.Models;

namespace MvcWeb.Services
{
    public interface ICartService
    {
        Task<Cart> GetOrCreateUserCartAsync(string userId);
        Task<bool> AddToCartAsync(string userId, int productId);
        Task<bool> UpdateQuantityAsync(string userId, int productId, int delta);
        Task<bool> DeleteCartItemAsync(string userId, int productId);
    }
}
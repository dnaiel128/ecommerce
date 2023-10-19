using LuminosECommerce.Models;
using EndavaTrainingsPlatform.DAL;
using LuminosECommerce.Models.DTOs;

namespace LuminosECommerce.DAL.Repositories
{
    public interface ICartRepository : IEntityBaseRepository<Cart>
    {
        Task AddBulkAsync(IEnumerable<Cart> newItems);
        Task ClearCartAsync(int userId);
        Task DeleteByItemAsync(Cart item);
        Task<IEnumerable<Item>> GetAllCartItemsAsync(int userId);
    }
}

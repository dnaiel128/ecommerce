using LuminosECommerce.Models;

namespace LuminosECommerce.BLL
{
    public interface ICartService : IService<Cart>
    {
        Task AddBulkAsync(IEnumerable<Cart> newItems);
        Task ClearCartAsync(int userId);
        Task DeleteByItemAsync(Cart item);
        Task<IEnumerable<Item>> GetAllCartItemsAsync(int userId);
    }
}

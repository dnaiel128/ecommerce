using LuminosECommerce.Models;
using LuminosECommerce.Models.DTOs;

namespace LuminosECommerce.BLL
{
    public interface ICartService : IService<Cart>
    {
        Task AddBulkAsync(CartItemsDTO newItems);
        Task ClearCartAsync(int userId);
        Task DeleteByItemAsync(Cart item);
        Task<IEnumerable<Item>> GetAllCartItemsAsync(int userId);
    }
}

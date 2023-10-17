using LuminosECommerce.Models;

namespace LuminosECommerce.BLL
{
    public interface ICartService : IService<Cart>
    {
        Task ClearCartAsync(int userId);
        Task<IEnumerable<Item>> GetAllCartItemsAsync(int userId);
    }
}

using LuminosECommerce.Models;
using EndavaTrainingsPlatform.DAL;

namespace LuminosECommerce.DAL.Repositories
{
    public interface ICartRepository : IEntityBaseRepository<Cart>
    {
        Task ClearCartAsync(int userId);
        Task<IEnumerable<Item>> GetAllCartItemsAsync(int userId);
    }
}

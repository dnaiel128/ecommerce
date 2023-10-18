using EndavaTrainingsPlatform.DAL;
using LuminosECommerce.Models;

namespace LuminosECommerce.DAL.Repositories
{
    public interface IOrderedItemRepository : IEntityBaseRepository<OrderedItem>
    {
        Task<IEnumerable<Item>> GetAllItemsOrderedAsync(int orderId);
        Task AddBulkAsync(IEnumerable<OrderedItem> orders);
    }
}

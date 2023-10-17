using LuminosECommerce.Models;

namespace LuminosECommerce.BLL
{
    public interface IOrderedItemService : IService<OrderedItem>
    {
        Task<IEnumerable<Item>> GetAllItemsOrderedAsync(int orderId);
        Task AddBulkAsync(IEnumerable<int> orderIds);
    }
}

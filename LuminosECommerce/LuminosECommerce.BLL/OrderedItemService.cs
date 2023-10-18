using LuminosECommerce.DAL.Repositories;
using LuminosECommerce.Models;

namespace LuminosECommerce.BLL
{
    public class OrderedItemService : Service<OrderedItem>, IOrderedItemService
    {
        private readonly IOrderedItemRepository _orderedRepository;

        public OrderedItemService(IOrderedItemRepository repository) : base(repository)
        {
            _orderedRepository = repository;
        }

        public Task AddBulkAsync(IEnumerable<OrderedItem> orders)
        {
            return (_repository as IOrderedItemRepository)!.AddBulkAsync(orders);
        }

        public Task<IEnumerable<Item>> GetAllItemsOrderedAsync(int orderId)
        {
            return (_repository as IOrderedItemRepository)!.GetAllItemsOrderedAsync(orderId);
        }
    }
}

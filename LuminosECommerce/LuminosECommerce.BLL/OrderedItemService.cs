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

        public Task AddBulkAsync(IEnumerable<int> orderIds)
        {
            return (_repository as IOrderedItemRepository)!.AddBulkAsync(orderIds);
        }

        public Task<IEnumerable<Item>> GetAllItemsOrderedAsync(int orderId)
        {
            return (_repository as IOrderedItemRepository)!.GetAllItemsOrderedAsync(orderId);
        }
    }
}

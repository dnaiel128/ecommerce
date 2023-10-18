using EndavaTrainingsPlatform.DAL;
using LuminosECommerce.Models;

namespace LuminosECommerce.DAL.Repositories
{
    public class OrderedItemRepository : EntityBaseRepository<OrderedItem>, IOrderedItemRepository
    {
        public OrderedItemRepository(StoreContext context) : base(context)
        {

        }
        public async Task AddBulkAsync(IEnumerable<OrderedItem> orders)
        {
            foreach(var order in orders) 
            {
                await _context.AddAsync(order);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAllItemsOrderedAsync(int orderId)
        {
            IEnumerable<Item> temp = new List<Item>();
            return temp;
        }
    }
}

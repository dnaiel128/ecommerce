using EndavaTrainingsPlatform.DAL;
using LuminosECommerce.Models;

namespace LuminosECommerce.DAL.Repositories
{
    public class OrderedItemRepository : EntityBaseRepository<OrderedItem>, IOrderedItemRepository
    {
        public OrderedItemRepository(StoreContext context) : base(context)
        {

        }
        public async Task AddBulkAsync(IEnumerable<int> orderIds)
        {
            foreach(var id in  orderIds) 
            {
                await _context.AddAsync(id);
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

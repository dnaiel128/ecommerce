using EndavaTrainingsPlatform.DAL;
using LuminosECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace LuminosECommerce.DAL.Repositories
{
    public class CartRepository : EntityBaseRepository<Cart>, ICartRepository
    {
        public CartRepository(StoreContext context) : base(context)
        {

        }

        public async Task ClearCartAsync(int userId)
        {
            var itemsToBeDeleted = await _context.Carts.Where(c => c.UserId == userId).ToListAsync();
            
            _context.RemoveRange(itemsToBeDeleted);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAllCartItemsAsync(int userId)
        {
            return await _context.Carts.Where(c => c.UserId == userId).Select(c=> c.Item).ToListAsync();
        }
    }
}

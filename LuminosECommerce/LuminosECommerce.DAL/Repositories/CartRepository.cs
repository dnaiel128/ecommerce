using EndavaTrainingsPlatform.DAL;
using LuminosECommerce.Models;
using LuminosECommerce.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LuminosECommerce.DAL.Repositories
{
    public class CartRepository : EntityBaseRepository<Cart>, ICartRepository
    {
        public CartRepository(StoreContext context) : base(context)
        {

        }

        public async Task AddBulkAsync(IEnumerable<Cart> newItems)
        {
            foreach(var cartItem in newItems)
            {
                await _context.Carts.AddAsync(cartItem);
            }

            await _context.SaveChangesAsync();
        }

        public async Task ClearCartAsync(int userId)
        {
            var itemsToBeDeleted = await _context.Carts.Where(c => c.UserId == userId).ToListAsync();
            
            _context.RemoveRange(itemsToBeDeleted);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteByItemAsync(Cart item)
        {
            var cartItem = await _context.Carts.Where(c => c.UserId== item.UserId && c.ItemId==item.ItemId).FirstOrDefaultAsync();
            
            _context.ChangeTracker.Clear();

            _context.Carts.Remove(cartItem);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CartItemDTO>> GetAllCartItemsAsync(int userId)
        {
            return await _context.Carts.Where(c => c.UserId == userId)
                .Select(c=> new CartItemDTO
                {
                    Item = c.Item,
                    Quantity = c.Quantity
                }).ToListAsync();
        }

        public async Task<Cart> GetByItemAsync(Cart item)
        {
            return await _context.Carts.Where(c => c.UserId == item.UserId && c.ItemId == item.ItemId).FirstOrDefaultAsync();
        }
    }
}

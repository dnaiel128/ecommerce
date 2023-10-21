using LuminosECommerce.DAL.Pagination;
using LuminosECommerce.DAL.Pagination.Models;
using LuminosECommerce.DAL.Repositories;
using LuminosECommerce.Models;
using LuminosECommerce.Models.DTOs;

namespace LuminosECommerce.BLL
{
    public class CartService : Service<Cart>, ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository repository) : base(repository)
        {
            _cartRepository = repository;
        }

        public Task AddBulkAsync(IEnumerable<Cart> newItems)
        {
            return (_repository as ICartRepository)!.AddBulkAsync(newItems);
        }

        public Task ClearCartAsync(int userId)
        {
            return (_repository as ICartRepository)!.ClearCartAsync(userId);
        }

        public Task DeleteByItemAsync(Cart item)
        {
            return (_repository as ICartRepository)!.DeleteByItemAsync(item);
        }

        public Task<IEnumerable<CartItemDTO>> GetAllCartItemsAsync(int userId)
        {
            return (_repository as ICartRepository)!.GetAllCartItemsAsync(userId);
        }

        public override async Task<Cart> AddAsync(Cart entity)
        {
            Cart existingItem = await (_repository as ICartRepository)!.GetByItemAsync(entity);

            if (existingItem == null) 
            {
                return await base.AddAsync(entity);
            }
            else
            {
                existingItem.Quantity = entity.Quantity;
                return await base.UpdateAsync(existingItem);
            }
        }
    }
}
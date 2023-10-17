using LuminosECommerce.DAL.Pagination;
using LuminosECommerce.DAL.Pagination.Models;
using LuminosECommerce.DAL.Repositories;
using LuminosECommerce.Models;

namespace LuminosECommerce.BLL
{
    public class CartService : Service<Cart>, ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository repository) : base(repository)
        {
            _cartRepository = repository;
        }

        public Task ClearCartAsync(int userId)
        {
            return (_repository as ICartRepository)!.ClearCartAsync(userId);
        }

        public Task<IEnumerable<Item>> GetAllCartItemsAsync(int userId)
        {
            return (_repository as ICartRepository)!.GetAllCartItemsAsync(userId);
        }
    }
}

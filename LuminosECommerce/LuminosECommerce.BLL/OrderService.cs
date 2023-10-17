using LuminosECommerce.DAL.Repositories;
using LuminosECommerce.Models;
using LuminosECommerce.Models.DTOs;

namespace LuminosECommerce.BLL
{
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IOderRepository _orderRepository;
        public OrderService(IOderRepository repository) : base(repository)
        {
            _orderRepository = repository;
        }

        public Task<IEnumerable<OrderDTO>> GetAllOrdersAsync(int userId)
        {
            return (_orderRepository as IOderRepository)!.GetAllOrdersAsync(userId);
        }
    }
}

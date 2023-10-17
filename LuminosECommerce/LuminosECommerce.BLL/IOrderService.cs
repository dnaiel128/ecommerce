using LuminosECommerce.Models;
using LuminosECommerce.Models.DTOs;

namespace LuminosECommerce.BLL
{
    public interface IOrderService : IService<Order>
    {
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync(int userId);
    }
}

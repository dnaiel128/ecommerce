using EndavaTrainingsPlatform.DAL;
using LuminosECommerce.Models;
using LuminosECommerce.Models.DTOs;

namespace LuminosECommerce.DAL.Repositories
{
    public interface IOderRepository : IEntityBaseRepository<Order>
    {
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync(int userId);
    }
}

using EndavaTrainingsPlatform.DAL;
using LuminosECommerce.Models;
using LuminosECommerce.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LuminosECommerce.DAL.Repositories
{
    public class OrderRepository : EntityBaseRepository<Order>, IOderRepository
    {
        public OrderRepository(StoreContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync(int userId)
        {
            return await _context.Orders.Where(o => o.UserId == userId)
                .Select(o => new OrderDTO
                {
                    Id = o.Id,
                    Total = o.Total,
                    OrderDate = o.OrderDate,
                    OrderedItems = o.OrderedItems.Select(or => new OrderedDTO
                    {
                        Id = or.Id,
                        OrderId = or.OrderId,
                        Item = new ItemDTO
                        {
                            Id = or.Item.Id,
                            Name = or.Item.Name,
                            Price = or.Item.Price,
                            Quantity = or.Quantity
                        }
                    }).ToList()
                }).ToListAsync();            
        }
    }
}

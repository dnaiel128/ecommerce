using LuminosECommerce.DAL.Pagination.Models;
using LuminosECommerce.DAL.Pagination;
using LuminosECommerce.Models;

namespace LuminosECommerce.BLL
{
    public interface IItemService : IService<Item>
    {
        Task<PagedModel<Item>> GetByPageWithFilterAndSortAsync(ItemQueryParameters queryParameters);
    }
}

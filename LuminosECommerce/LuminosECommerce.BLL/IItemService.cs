using LuminosECommerce.DAL.Pagination.Models;
using LuminosECommerce.DAL.Pagination;
using LuminosECommerce.Models;

namespace LuminosECommerce.BLL
{
    public interface IItemService
    {
        Task<PagedModel<Item>> GetByPageWithFilterAndSortAsync(ItemQueryParameters queryParameters);
    }
}

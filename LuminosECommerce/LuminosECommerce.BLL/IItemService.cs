using LuminosECommerce.DAL.Pagination.Models;
using LuminosECommerce.DAL.Pagination;
using LuminosECommerce.Models;
using LuminosECommerce.Models.DTOs;

namespace LuminosECommerce.BLL
{
    public interface IItemService : IService<Item>
    {
        Task<PagedModel<Item>> GetByPageWithFilterAndSortAsync(ItemQueryParameters queryParameters);
        Task<List<Item>> GetByIdAsyncWithSP(int id);
        Task<List<Item>> AutocompleteAsync(string name);
    }
}

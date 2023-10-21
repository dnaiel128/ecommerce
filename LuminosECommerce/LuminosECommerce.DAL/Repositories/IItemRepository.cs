using EndavaTrainingsPlatform.DAL;
using LuminosECommerce.DAL.Pagination;
using LuminosECommerce.DAL.Pagination.Models;
using LuminosECommerce.Models;

namespace LuminosECommerce.DAL.Repositories
{
    public interface IItemRepository : IEntityBaseRepository<Item>
    {
        Task<PagedModel<Item>> GetByPageWithFilterAndSortAsync(ItemQueryParameters queryParameters);

        Task<List<Item>> GetByIdAsyncWithSP(int id);
    }
}

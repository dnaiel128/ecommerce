using LuminosECommerce.DAL.Pagination;
using LuminosECommerce.DAL.Pagination.Models;
using LuminosECommerce.DAL.Repositories;
using LuminosECommerce.Models;

namespace LuminosECommerce.BLL
{
    public class ItemService : Service<Item>, IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository repository) : base(repository)
        {
            _itemRepository = repository;
        }

        public Task<List<Item>> GetByIdAsyncWithSP(int id)
        {
            return (_repository as IItemRepository)!.GetByIdAsyncWithSP(id);
        }

        public Task<PagedModel<Item>> GetByPageWithFilterAndSortAsync(ItemQueryParameters queryParameters)
        {
            return (_repository as IItemRepository)!.GetByPageWithFilterAndSortAsync(queryParameters);
        }
    }
}

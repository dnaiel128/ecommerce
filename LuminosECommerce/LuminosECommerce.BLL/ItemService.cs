using LuminosECommerce.DAL.Pagination;
using LuminosECommerce.DAL.Pagination.Models;
using LuminosECommerce.DAL.Repositories;
using LuminosECommerce.Models;
using LuminosECommerce.Models.DTOs;

namespace LuminosECommerce.BLL
{
    public class ItemService : Service<Item>, IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository repository) : base(repository)
        {
            _itemRepository = repository;
        }

        public Task<List<Item>> AutocompleteAsync(string name)
        {
            return (_repository as IItemRepository)!.AutocompleteAsync(name);
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

﻿using EndavaTrainingsPlatform.DAL;
using LuminosECommerce.DAL.Pagination;
using LuminosECommerce.DAL.Pagination.Models;
using LuminosECommerce.Models;
using LuminosECommerce.Models.DTOs;

namespace LuminosECommerce.DAL.Repositories
{
    public interface IItemRepository : IEntityBaseRepository<Item>
    {
        Task<PagedModel<Item>> GetByPageWithFilterAndSortAsync(ItemQueryParameters queryParameters);

        Task<List<Item>> GetByIdAsyncWithSP(int id);
        Task<List<Item>> AutocompleteAsync(string name);
    }
}

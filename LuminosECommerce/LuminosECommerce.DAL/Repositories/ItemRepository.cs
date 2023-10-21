using EndavaTrainingsPlatform.DAL;
using LuminosECommerce.DAL.Pagination;
using LuminosECommerce.DAL.Pagination.Models;
using LuminosECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace LuminosECommerce.DAL.Repositories
{
    public class ItemRepository : EntityBaseRepository<Item>, IItemRepository
    {
        public ItemRepository(StoreContext context) : base(context)
        {

        }
        public async Task<PagedModel<Item>> GetByPageWithFilterAndSortAsync(ItemQueryParameters queryParameters)
        {
            return await _context.Items.AsNoTracking().Include(d => d.UserReviews).PaginateWithFilterAndSortAsync(queryParameters);
        }

        public async Task<List<Item>> GetByIdAsyncWithSP(int id)
        {
            return await _context.Items.FromSqlRaw($"SelectItem {id}").ToListAsync();
        }

        public override async Task UpdateAsync(Item item)
        {
            await _context.Database
                .ExecuteSqlRawAsync($"UpdateItem {item.Id}, '{item.Name}', {item.Price}, '{item.Description}', '{item.ImageFolderPath}'");
        }
    }
}

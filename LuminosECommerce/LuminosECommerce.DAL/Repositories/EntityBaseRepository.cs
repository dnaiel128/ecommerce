using LuminosECommerce.DAL;
using LuminosECommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EndavaTrainingsPlatform.DAL
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        protected readonly StoreContext _context;
        public EntityBaseRepository(StoreContext context)
        {
            _context = context;
        }

        public virtual async Task<T> GetByIdAsync(int id) => await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T temp = new T { Id = id };

            _context.ChangeTracker.Clear();

            _context.Set<T>().Remove(temp);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.ChangeTracker.Clear();

            EntityEntry entityEntry = _context.Entry(entity);

            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        /*public virtual async Task<PagedModel<T>> GetByPageAsync(PageOptions pageOptions)
        {
            return await _context.Set<T>().AsNoTracking().PaginateAsync(pageOptions);
        }*/
    }
}

using LuminosECommerce.Models;

namespace EndavaTrainingsPlatform.DAL
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int Id);

        //Task<PagedModel<T>> GetByPageAsync(PageOptions pageOptions);
    }
}
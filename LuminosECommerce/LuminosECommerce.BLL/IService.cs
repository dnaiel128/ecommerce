using LuminosECommerce.DAL.Pagination.Models;
using LuminosECommerce.DAL.Pagination;
using LuminosECommerce.Models;

namespace LuminosECommerce.BLL
{
    public interface IService<T> where T : class, IEntityBase, new()
    {
        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(int Id);

        //Task<PagedModel<T>> GetByPageAsync(PageOptions pageOptions);
    }
}

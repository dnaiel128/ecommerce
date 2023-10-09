using EndavaTrainingsPlatform.DAL;
using LuminosECommerce.DAL.Pagination;
using LuminosECommerce.DAL.Pagination.Models;
using LuminosECommerce.Models;

namespace LuminosECommerce.BLL
{
    public class Service<T> : IService<T> where T : class, IEntityBase, new()
    {
        protected readonly IEntityBaseRepository<T> _repository;

        public Service(IEntityBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(int Id)
        {
            return _repository.DeleteAsync(Id);
        }

        public Task<T> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        /*public Task<PagedModel<T>> GetByPageAsync(PageOptions pageOptions)
        {
            return _repository.GetByPageAsync(pageOptions);
        }*/

        public async Task<T> UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
            return entity;
        }
    }
}

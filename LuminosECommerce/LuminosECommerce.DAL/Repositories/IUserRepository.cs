using EndavaTrainingsPlatform.DAL;
using LuminosECommerce.Models;

namespace LuminosECommerce.DAL.Repositories
{
    public interface IUserRepository : IEntityBaseRepository<User>
    {
        //Task<User> GetByUserAndPasswordAsync(string username, string password);
        Task<User> GetByUsernameAsync(string username);
    }
}

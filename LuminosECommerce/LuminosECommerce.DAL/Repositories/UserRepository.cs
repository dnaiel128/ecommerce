using EndavaTrainingsPlatform.DAL;
using LuminosECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace LuminosECommerce.DAL.Repositories
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(StoreContext context) : base(context)
        {
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        /*public async Task<User> GetByUserAndPasswordAsync(string username, string password)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username && u.Password == password);
        }*/
    }
}

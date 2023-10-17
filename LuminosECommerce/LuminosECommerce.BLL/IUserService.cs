using LuminosECommerce.BLL.Helpers;
using LuminosECommerce.Models;

namespace LuminosECommerce.BLL
{
    public interface IUserService : IService<User>
    {
        Password CreatePasswordHash(string password);
        string CreateToken(User user);

        //Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<User> GetByUsernameAsync(string username);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}

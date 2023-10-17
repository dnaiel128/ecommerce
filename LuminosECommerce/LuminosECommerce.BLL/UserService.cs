using LuminosECommerce.BLL.Helpers;
using LuminosECommerce.DAL.Repositories;
using LuminosECommerce.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LuminosECommerce.BLL
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository repository, IConfiguration configuration) : base(repository)
        {
            _userRepository = repository;
            _configuration = configuration;
        }

        public Password CreatePasswordHash(string password)
        {
            Password newPasswordHash = new Password();

            using (var hmac = new HMACSHA512())
            {
                newPasswordHash.PasswordSalt = hmac.Key;
                newPasswordHash.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            return newPasswordHash;
        }

        public string CreateToken(User user)
        {
            string userRole = string.Empty;
            if(user.IsAdmin) { userRole = "Admin"; }
            else { userRole = "User"; }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, userRole)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Secret").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public Task<User> GetByUsernameAsync(string username)
        {
            return (_userRepository as IUserRepository)!.GetByUsernameAsync(username);
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        /*public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _userRepository.GetByUserAndPasswordAsync(model.Username,model.Password);

            if(user == null) { return null; }

            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }*/

        /*private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }*/
    }
}

using LuminosECommerce.BLL;
using LuminosECommerce.BLL.Helpers;
using LuminosECommerce.Models;
using LuminosECommerce.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LuminosECommerce.UI.Controllers
{
    public class UserController : Controller
    {
        protected IUserService _userService;
        private IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("/user/register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody]UserDTO requestUser)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid new user");
            }

            try
            {
                Password hashedPassword = _userService.CreatePasswordHash(requestUser.Password);

                User newUser = new User()
                {
                    Username = requestUser.Username,
                    FirstName = requestUser.FirstName,
                    LastName = requestUser.LastName,
                    IsAdmin = requestUser.IsAdmin,
                    PasswordHash = hashedPassword.PasswordHash,
                    PasswordSalt = hashedPassword.PasswordSalt
                };

                await _userService.AddAsync(newUser);

                return Ok(newUser);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }

        }


        [HttpPost]
        [Route("/user/login")]
        [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Authenticate([FromBody]LoginDTO login)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Wrong login information");
            }

            var user = await _userService.GetByUsernameAsync(login.Username);

            if (user == null)
                return BadRequest("User not found");

            if(!_userService.VerifyPasswordHash(login.Password,user.PasswordHash,user.PasswordSalt))
            {
                return BadRequest("Wrong password");
            }

            string token = _userService.CreateToken(user);

            return Ok(token);
        }

        [HttpGet]
        [Route("/user")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetById(int id) 
        { 
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }
    }
}

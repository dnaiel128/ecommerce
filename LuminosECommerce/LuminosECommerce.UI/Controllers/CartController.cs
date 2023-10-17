using LuminosECommerce.BLL;
using LuminosECommerce.DAL.Pagination;
using LuminosECommerce.DAL.Pagination.Models;
using LuminosECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LuminosECommerce.UI.Controllers
{
    public class CartController : Controller
    {
        protected ICartService _cartService;
        private readonly UserManager<IdentityUser> _userManager;

        public CartController(ICartService cartService, UserManager<IdentityUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }

        [Route("/cart/getAllCartProducts")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Item>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllCartProducts()
        {
            var cartProducts = await _cartService.GetAllCartItemsAsync(1);

            return Ok(cartProducts);
        }

        [Route("/cart/clearCart")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ClearCart()
        {
            await _cartService.ClearCartAsync(1);

            return Ok();
        }
    }
}

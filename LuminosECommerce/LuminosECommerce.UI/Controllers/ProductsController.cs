using LuminosECommerce.BLL;
using LuminosECommerce.DAL.Pagination.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LuminosECommerce.UI.Controllers
{
    public class ProductsController : Controller
    {
        protected IItemService _itemService;
        private readonly UserManager<IdentityUser> _userManager;

        public ProductsController(IItemService itemService, UserManager<IdentityUser> userManager)
        {
            _itemService = itemService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string? name, bool? price, bool? reviewNumber, bool? highestReview, int pageIndex)
        {
            ItemQueryParameters queryParametes = new ItemQueryParameters { SortByPriceAscending=price,
                SortByHighestReviewsDescending=highestReview, SortByNumberOfReviewsDescending=reviewNumber, PageIndex=pageIndex };
            
            if(!string.IsNullOrEmpty(name))
            {
                queryParametes.Name = name;
            }

            var items = await _itemService.GetByPageWithFilterAndSortAsync(queryParametes);

            return View();
        }
    }
}

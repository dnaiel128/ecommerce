﻿using LuminosECommerce.BLL;
using LuminosECommerce.DAL.Pagination;
using LuminosECommerce.DAL.Pagination.Models;
using LuminosECommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LuminosECommerce.UI.Controllers
{
    public class ProductsController : Controller
    {
        protected IItemService _itemService;

        public ProductsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task<IActionResult> Index(string? name, bool? price, bool? reviewNumber, bool? highestReview, int pageIndex)
        {
            ItemQueryParameters queryParametes = new ItemQueryParameters
            {
                SortByPriceAscending = price,
                SortByHighestReviewsDescending = highestReview,
                SortByNumberOfReviewsDescending = reviewNumber,
                PageIndex = pageIndex
            };

            if (!string.IsNullOrEmpty(name))
            {
                queryParametes.Name = name;
            }

            var items = await _itemService.GetByPageWithFilterAndSortAsync(queryParametes);

            return View("Index", items);
        }

        [Route("/product/getAll")]
        [HttpGet]
        [ProducesResponseType(typeof(PagedModel<Item>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllObjects(string? name, bool? price, bool? reviewNumber, bool? highestReview, int pageIndex)
        {
            ItemQueryParameters queryParametes = new ItemQueryParameters
            {
                SortByPriceAscending = price,
                SortByHighestReviewsDescending = highestReview,
                SortByNumberOfReviewsDescending = reviewNumber,
                PageIndex = pageIndex
            };

            var items = await _itemService.GetByPageWithFilterAndSortAsync(queryParametes);

            return Ok(items);

        }

        [Route("/product")]
        [HttpGet]
        [ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            if(id < 0)
            {
                return BadRequest("Id must be greater than 0");
            }

            try
            {
                //var item = await _itemService.GetByIdAsync(id);

                var item = await _itemService.GetByIdAsyncWithSP(id);

                if (item.Count == 0)
                {
                    return new NoContentResult();
                }    

                return Ok(item[0]);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            } 
        }

        [Route("/product")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddProduct([FromBody]Item item)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _itemService.AddAsync(item);
                return Created("", item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("/product")]
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProduct([FromBody] Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _itemService.UpdateAsync(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("/product")]
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProduct([FromQuery] int itemId)
        {
            if (itemId < 0)
            {
                return BadRequest("Id must be greater than 0");
            }

            try
            {
                await _itemService.DeleteAsync(itemId);
                return Accepted();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("/product/autocomplete")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Autocomplete([FromQuery] String name)
        {
            if (name.Length<3)
            {
                return BadRequest("Name less than 3 characters");
            }

            try
            {
                var items = await _itemService.AutocompleteAsync(name);
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("/product/search")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SearchProducts([FromQuery] String name)
        {
            try
            {
                if(string.IsNullOrEmpty(name))
                {
                    name = string.Empty;
                }

                var items = await _itemService.AutocompleteAsync(name);
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

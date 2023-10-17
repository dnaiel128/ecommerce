using LuminosECommerce.BLL;
using LuminosECommerce.DAL.Pagination.Models;
using LuminosECommerce.DAL.Pagination;
using LuminosECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LuminosECommerce.UI.Models;
using LuminosECommerce.Models.DTOs;

namespace LuminosECommerce.UI.Controllers
{
    public class OrderController : Controller
    {
        protected IOrderService _orderService;
        protected IOrderedItemService _orderedItemService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService,
            IMapper mapper, IOrderedItemService orderedItemService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _orderedItemService = orderedItemService;
        }

        [Route("/order/getAllOrders")]
        [HttpGet]
        [ProducesResponseType(typeof(List<OrderDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllOrders()
        {
            var allOrders = await _orderService.GetAllOrdersAsync(1);
            
            return Ok(allOrders);
        }

        [Route("/order/addOrder")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddNewOrder([FromBody]OrderRequestDTO newOrder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Order orderToAdd = _mapper.Map<Order>(newOrder);

                await _orderService.AddAsync(orderToAdd);

                foreach(var id in newOrder.ItemsIds)
                {
                    OrderedItem item = new OrderedItem() { ItemId=id, OrderId=orderToAdd.Id};

                    await _orderedItemService.AddAsync(item);
                }

                return Created("", newOrder);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }     
        }
    }
}

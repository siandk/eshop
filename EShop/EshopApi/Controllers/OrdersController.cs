using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;

namespace EshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public OrderController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> Get(int? customerId = null)
        {
            List<OrderDto> orders = new List<OrderDto>();
            if (customerId.HasValue)
            {
                orders = await _orderService.GetOrdersByCustomer(customerId.Value).ToListAsync();
            }
            else
            {
                orders = await _orderService.GetOrders().ToListAsync();
            }
            return Ok(orders);
        }
        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderDto>> Get(int orderId)
        {
            OrderDto Order = await _orderService.GetOrderById(orderId).FirstOrDefaultAsync();
            return Order != null ? Ok(Order) : StatusCode(StatusCodes.Status404NotFound, "Order Not Found");
        }
        [HttpPost]
        public async Task<ActionResult<OrderDto>> Post(OrderDto orderDto)
        {
            Order order = orderDto.MapToOrder();
            await _orderService.Create<Order>(order);
            return Created($"/api/order/{order.OrderId}", order);
        }
    }
}
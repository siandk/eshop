﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using EshopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;

namespace EshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public OrdersController(IProductService productService, IOrderService orderService)
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
            await _orderService.Create(order);
            return Created($"/api/orders/{order.OrderId}", order);
        }
        [HttpPost("Checkout")]
        public async Task<ActionResult<CheckoutDto>> PostCheckout(CheckoutDto checkoutDto)
        {
            OrderDto order = checkoutDto.Order;
            Customer customer = checkoutDto.Customer.ToCustomer();
            await _orderService.CheckoutOrder(order, customer);
            return Created($"/api/orders/{order.OrderId}", order);
        }
    }
}
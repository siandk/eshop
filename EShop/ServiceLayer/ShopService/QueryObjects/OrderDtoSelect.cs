using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ShopService.QueryObjects
{
    public static class OrderDtoSelect
    {
        public static IQueryable<OrderDto> MapOrderDto(this IQueryable<Order> orders)
        {
            return orders.Include(o => o.Customer).Include(o => o.OrderLines).ThenInclude(l => l.Product).Select(o => new OrderDto()
            {
                CustomerId = o.CustomerId,
                CustomerName = o.Customer.Name,
                OrderDate = o.OrderDate,
                OrderLines = o.OrderLines.Select(l => new OrderLineDto()
                {
                    ProductId = l.ProductId,
                    ProductName = l.Product.Name,
                    ProductUnitPrice = l.Product.UnitPrice,
                    Quantity = l.LineQuantity,
                    LinePrice = l.LinePrice,
                    ProductUnitCostPrice = l.UnitCostPrice

                }).ToList()
            });
        }
    }
}

using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;
using ServiceLayer.ShopService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ShopService.Concrete
{
    public class OrderService : GenericService, IOrderService
    {
        public OrderService(ShopContext context) : base(context)
        {
        }

        public async Task CheckoutOrder(OrderDto sessionOrder, Customer customer)
        {
            Order order = sessionOrder.MapToOrder();
            order.CustomerId = customer.CustomerId;
            order.OrderLines.ForEach(l => l.UnitCostPrice = GetCostPrice(l.ProductId));
            order.OrderLines.ForEach(l => l.Product = _context.Products.Find(l.ProductId));
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }
        public IQueryable<OrderDto> GetOrders()
        {
            return _context.Orders.Select(o => o).MapOrderDto();
        }
        public IQueryable<OrderDto> GetOrdersByCustomer(int customerId)
        {
            return _context.Orders.Where(o => o.CustomerId == customerId).MapOrderDto();
        }
        private decimal GetCostPrice(int productId)
        {
            if (_context.Products.Any(p => p.ProductId == productId))
            {
                var ProductPrices = _context.Products.Where(p => p.ProductId == productId).Include(p => p.ProductSupplierPrices).SelectMany(p => p.ProductSupplierPrices);

                return ProductPrices.Count() > 0 ? ProductPrices.OrderBy(pr => pr.Price).FirstOrDefault().Price : 0M;
            }
            else
            {
                return 0M;
            }
        }
    }
}

using DataLayer.Entities;
using ServiceLayer.ShopService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ShopService.Interfaces
{
    public interface IOrderService : IGenericService
    {
        Task CheckoutOrder(OrderDto order, Customer customer);
        IQueryable<OrderDto> GetOrders();
        IQueryable<OrderDto> GetOrdersByCustomer(int customerId);
    }
}

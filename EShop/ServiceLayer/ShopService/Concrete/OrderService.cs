using DataLayer;
using ServiceLayer.ShopService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ShopService.Concrete
{
    public class OrderService : GenericService, IOrderService
    {
        public OrderService(ShopContext context) : base(context)
        {
        }
    }
}

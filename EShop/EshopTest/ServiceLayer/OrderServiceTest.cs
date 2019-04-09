using DataLayer;
using DataLayer.Entities;
using EshopTest.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.ShopService.Concrete;
using ServiceLayer.ShopService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EshopTest.ServiceLayer
{
    [TestClass]
    public class OrderServiceTest
    {
        [TestMethod]
        public void check_order_line_product_cost_price()
        {
            // ARRANGE
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "check_order_line_product_cost_price")
                .Options;
            using (var context = new ShopContext(options))
            {
                var dataSeed = new TestData(context);
                dataSeed.Initialize();
                Customer customer = context.Customers.Find(1);
                OrderDto order = new OrderDto()
                {
                    OrderLines = new List<OrderLineDto>()
                    {
                        new OrderLineDto()
                        {
                            ProductId = 1,
                            Quantity = 2,
                        }
                    }
                };

                // ACT
                OrderService _service = new OrderService(context);
                _service.CheckoutOrder(order, customer);
                // ASSERT
                Assert.AreEqual(7M, context.Orders.Last().OrderLines[0].UnitCostPrice); 
            }
        }
    }
}

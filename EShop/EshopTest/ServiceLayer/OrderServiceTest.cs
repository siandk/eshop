using DataLayer;
using DataLayer.Entities;
using EshopTest.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.ShopService.Concrete;
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
                // ACT
                OrderService _service = new OrderService(context);
                var order = _service.GetOrderById(3).First();
                // ASSERT
                Assert.AreEqual(order.OrderLines[0].ProductUnitCostPrice, 30M); 
            }
        }
    }
}

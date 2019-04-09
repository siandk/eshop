using DataLayer;
using EshopTest.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EshopTest.DataLayer
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void check_order_computed_amount_total()
        {
            // ARRANGE
            using (var context = new ShopContext(SqlContext.TestDbContextOptions()))
            {
                // ACT
                var order = context.Orders.Include(o => o.OrderLines).ThenInclude(l => l.Product).First(o => o.OrderId == 2);

                // ASSERT
                Assert.AreEqual(3, order.OrderLines.Count()); // Check that the correct order has been fetched
                Assert.AreEqual(240M, order.AmountTotal); // Check total amount on order
            }
        }
        [TestMethod]
        public void check_order_line_computed_line_total()
        {
            // ARRANGE
            using (var context = new ShopContext(SqlContext.TestDbContextOptions()))
            {
                // ACT
                var order = context.Orders.Include(o => o.OrderLines).ThenInclude(l => l.Product).First(o => o.OrderId == 4);

                // ASSERT
                Assert.AreEqual(7, order.OrderLines[0].LineQuantity); // Check Quantity
                Assert.AreEqual(30M, order.OrderLines[0].Product.UnitPrice); // Check Unit Price
                Assert.AreEqual(210M, order.OrderLines[0].LinePrice); // Check Quantity * Unit Price
            }
        }

    }
}

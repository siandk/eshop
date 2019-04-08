using DataLayer;
using DataLayer.Entities;
using EshopTest.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace EshopTest.DataLayer
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void set_category_parentpath()
        {
            // ARRANGE
            using (var context = new ShopContext(SqlContext.TestDbContextOptions()))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                // ACT
                var dataSeed = new TestData(context);
                dataSeed.Initialize();

            // ASSERT
                Category category = context.Categories
                                            .Include(c => c.ChildCategories)
                                            .Where(c => c.ParentCategoryId == 3)
                                            .First();
                Assert.AreEqual("Layer 3", category.Name); // Check that the correct category has been fetched
                Assert.AreEqual("/1/2/3/", category.ParentPath); // Check that the parentpath has been set correctly
            }
        }
        [TestMethod]
        public void get_products_by_category_parentpath()
        {
            // ARRANGE            
            using (var context = new ShopContext(SqlContext.TestDbContextOptions()))
            {
                // ACT
                var categories = context.Categories
                                        .Include(c => c.ChildCategories)
                                        .Include(c => c.Products)
                                        .Where(c => c.ParentPath != null && c.ParentPath.Contains("/2/"))
                                        .ToList();
                var products = categories.SelectMany(c => c.Products).ToList();
                // ASSERT
                Assert.AreEqual(4, products.Count());
            }

        }
    }
}

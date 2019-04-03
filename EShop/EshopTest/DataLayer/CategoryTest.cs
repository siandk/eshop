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
            // ACT
            using (var context = new ShopContext(SqlContext.TestDbContextOptions()))
            {
                List<Category> categoryList = new List<Category>()
                {
                    new Category() {Name = "Layer 0"},
                    new Category() {Name = "Layer 1", ParentCategoryId = 1},
                    new Category() {Name = "Layer 2", ParentCategoryId = 2},
                    new Category() {Name = "Layer 3", ParentCategoryId = 3}
                };
                context.Categories.AddRange(categoryList);
                context.SaveChanges();

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
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "get_products_by_category_parentpath")
                .Options;
            
            using (var context = new ShopContext(options))
            {
                List<Category> categoryList = new List<Category>()
                {
                    new Category() {Name = "Layer 0"},
                    new Category() {Name = "Layer 1", ParentCategoryId = 1},
                    new Category() {Name = "Layer 2", ParentCategoryId = 2},
                    new Category() {Name = "Layer 2.A", ParentCategoryId = 2},
                    new Category() {Name = "Layer 3", ParentCategoryId = 3}
                };
                context.Categories.AddRange(categoryList);

                List<Product> productList = new List<Product>()
                {
                    new Product() {Name = "Test Product 01", CategoryId = 1, UnitPrice = 30M},
                    new Product() {Name = "Test Product 02", CategoryId = 1, UnitPrice = 30M},
                    new Product() {Name = "Test Product 03", CategoryId = 2, UnitPrice = 30M},
                    new Product() {Name = "Test Product 04", CategoryId = 2, UnitPrice = 30M},
                    new Product() {Name = "Test Product 05", CategoryId = 3, UnitPrice = 30M},
                    new Product() {Name = "Test Product 06", CategoryId = 3, UnitPrice = 30M},
                    new Product() {Name = "Test Product 07", CategoryId = 4, UnitPrice = 30M},
                    new Product() {Name = "Test Product 08", CategoryId = 5, UnitPrice = 30M}
                };
                context.Products.AddRange(productList);
                context.SaveChanges();

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

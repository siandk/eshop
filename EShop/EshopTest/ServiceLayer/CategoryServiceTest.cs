using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.ShopService.Concrete;
using System.Linq;

namespace EshopTest.ServiceLayer
{
    [TestClass]
    public class CategoryServiceTest
    {
        [TestMethod]
        public void get_category_hierarchy()
        {
            // ARRANGE
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "get_category_hierarchy")
                .Options;
            using (var context = new ShopContext(options))
            {
                List<Category> categoryList = new List<Category>()
                {
                    new Category() {Name = "Layer 0"},
                    new Category() {Name = "Layer 1", ParentCategoryId = 1},
                    new Category() {Name = "Layer 1.A", ParentCategoryId = 1},
                    new Category() {Name = "Layer 1.B", ParentCategoryId = 1},
                    new Category() {Name = "Layer 2", ParentCategoryId = 2},
                    new Category() {Name = "Layer 3", ParentCategoryId = 5}
                };
                context.Categories.AddRange(categoryList);
                context.SaveChanges();

                // ACT
                CategoryService _service = new CategoryService(context);
                var categoryDtos = _service.GetCategoryTree().ToList();
                // ASSERT
                Assert.AreEqual(6, categoryDtos.Count()); // All categories loaded
                Assert.AreEqual(3, categoryDtos.Where(c => c.ParentCategoryId == null).SelectMany(c => c.ChildCategories).Count()); // 3 children directly under top level
                Assert.AreEqual(1, categoryDtos.First().ChildCategories.First().ChildCategories.First().ChildCategories.Count()); // Nested categories are also loaded
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.ShopService.Concrete;
using System.Linq;
using EshopTest.Utilities;

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
                var dataSeed = new TestData(context);
                dataSeed.Initialize();
                // ACT
                CategoryService _service = new CategoryService(context);
                var categoryDtos = _service.GetCategoryTree().ToList();
                // ASSERT
                Assert.AreEqual(5, categoryDtos.Count()); // All categories loaded
                Assert.AreEqual(1, categoryDtos.Where(c => c.ParentCategoryId == null).SelectMany(c => c.ChildCategories).Count()); // 1 child directly under top level
                Assert.AreEqual(1, categoryDtos.First().ChildCategories.First().ChildCategories.First().ChildCategories.Count()); // Nested categories are also loaded
            }
        }
    }
}

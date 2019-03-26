using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ShopService
{
    public class CategoryListDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Category> ChildCategories { get; set; } 
        public Category ParentCategory { get; set; }
        public int ProductCount { get; set; }
    }
}

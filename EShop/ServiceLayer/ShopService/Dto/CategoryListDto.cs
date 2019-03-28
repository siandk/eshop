using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ShopService.Dto
{
    public class CategoryListDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<CategoryListDto> ChildCategories { get; set; } 
        public int? ParentId { get; set; }
    }
}

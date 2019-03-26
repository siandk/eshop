using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ShopService.Concrete
{
    public class CategoryListService
    {
        private readonly ShopContext _context;

        public CategoryListService(ShopContext context)
        {
            _context = context;
        }

        public List<CategoryListDto> GetCategoryTree()
        {
            return _context.Categories.FromSql("sp_GetAllCategories")
                        .MapCategoryToDto()
                        .ToList() // Get all categories from the DB, before filtering. Otherwise ChildCategories are not included.
                        .Where(c => c.ParentCategory == null) // Return only top level categories. Children are available through navigation properties
                        .ToList();
        }
        //public Category GetSubCategories(int categoryId)
        //{
        //    return _context.Categories.FromSql("sp_GetSubCategories @p0", categoryId).ToList().First();
        //}
    }
}

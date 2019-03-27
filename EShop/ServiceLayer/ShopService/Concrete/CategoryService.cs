using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;
using ServiceLayer.ShopService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ShopService.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ShopContext _context;

        public CategoryService(ShopContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Gets the top level of the category hierarchy. Children are available through the navigation properties
        /// </summary>
        /// <returns></returns>
        public List<CategoryListDto> GetCategoryTree()
        {
            return _context.Categories.FromSql("sp_GetAllCategories")
                        .MapCategoryToListDto()
                        .ToList() // Get all categories from the DB, before filtering. Otherwise ChildCategories are not included.
                        .Where(c => c.ParentCategory == null) // Return only top level categories. Children are available through navigation properties
                        .ToList();
        }
        public IQueryable<CategoryListDto> GetSubCategories(int categoryId)
        {
            return _context.Categories.FromSql("sp_GetSubCategories @p0", categoryId)
                .MapCategoryToListDto();
        }
    }
}

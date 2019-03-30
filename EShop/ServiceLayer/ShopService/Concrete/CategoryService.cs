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
using System.Threading.Tasks;

namespace ServiceLayer.ShopService.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ShopContext _context;

        public CategoryService(ShopContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryListDto>> GetCategoryTreeInclude()
        {
            return await _context.Categories.Include(c => c.ChildCategories).Where(c => c.ParentCategoryId == null).MapCategoryListDtoTest();
        }
        public async Task<List<CategoryListDto>> GetCategoryTree()
        {
            return await _context.Categories.FromSql("sp_GetSubCategories @p0", 1)
                        .MapCategoryListDto();
                        // Get all categories from the DB, before filtering. Otherwise ChildCategories are not included.
                        //.Where(c => c.ParentCategory == null) // Return only top level categories. Children are available through navigation properties
                        //.ToList();
        }
    }
}

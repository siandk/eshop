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
    public class CategoryService : GenericService, ICategoryService
    {
        public CategoryService(ShopContext _context) : base(_context) { }
        public IQueryable<Category> GetCategoryTree()
        {
            return _context.Categories
                        .Include(c => c.ChildCategories);
        }
        public async Task<Category> GetCategoryById(int? id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
        }
    }
}

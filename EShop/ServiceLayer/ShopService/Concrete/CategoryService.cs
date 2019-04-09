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
        public IQueryable<Category> GetCategoryById(int? id)
        {
            // Fetch all categories, to make sure the parent/child relationships are loaded
            var categories = _context.Categories.ToList();
            return categories.AsQueryable().Where(c => c.CategoryId == id);
        }
    }
}

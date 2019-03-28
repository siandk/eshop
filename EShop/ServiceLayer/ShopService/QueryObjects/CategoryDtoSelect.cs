using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ShopService.QueryObjects
{
    public static class CategoryDtoSelect
    {
        public static async Task<List<CategoryListDto>> MapCategoryListDto(this IQueryable<Category> categories)
        {
            var categoriesResult = await categories.ToListAsync();

            return categoriesResult.Where(c => c.ParentCategoryId == null).Select(c => new CategoryListDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                ChildCategories = c.ChildCategories.Any() ? c.ChildCategories.MapCategoryListDtoRecursive().ToList() : new List<CategoryListDto>(),
                ParentId = c.ParentCategoryId
            }).ToList();
        }
        public static IEnumerable<CategoryListDto> MapCategoryListDtoRecursive(this IEnumerable<Category> categories)
        {
            return categories.Select(c => new CategoryListDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                ChildCategories = c.ChildCategories.Any() ? c.ChildCategories.MapCategoryListDtoRecursive().ToList() : new List<CategoryListDto>(),
                ParentId = c.ParentCategoryId
            });
        }
    }
}

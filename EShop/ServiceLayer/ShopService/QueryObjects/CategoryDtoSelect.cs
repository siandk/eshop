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
        public static IQueryable<CategoryListDto> MapCategoryListDto(this IQueryable<Category> categories)
        {
            
            return categories.Where(c => c.ParentCategoryId == null).Select(c => new CategoryListDto()
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                ChildCategories = c.ChildCategories.Any() ? c.ChildCategories.MapCategoryListDtoRecursive() : new List<CategoryListDto>(),
                ParentId = c.ParentCategoryId,
                ParentPath = c.ParentPath
            });
        }
        private static IEnumerable<CategoryListDto> MapCategoryListDtoRecursive(this IEnumerable<Category> categories)
        {
            return categories.Select(c => new CategoryListDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                ChildCategories = c.ChildCategories.Any() ? c.ChildCategories.MapCategoryListDtoRecursive() : new List<CategoryListDto>(),
                ParentId = c.ParentCategoryId,
                ParentPath = c.ParentPath
            });
        }
    }
}

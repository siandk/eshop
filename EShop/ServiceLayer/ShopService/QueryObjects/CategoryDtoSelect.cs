using DataLayer.Entities;
using ServiceLayer.ShopService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ShopService.QueryObjects
{
    public static class CategoryListDtoSelect
    {
        public static IQueryable<CategoryListDto> MapCategoryToListDto(this IQueryable<Category> categories)
        {
            return categories.Select(c => new CategoryListDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                ChildCategories = c.ChildCategories,
                ParentCategory = c.ParentCategory,
                ProductCount = c.Products.Count()
            });
        }
    }
}

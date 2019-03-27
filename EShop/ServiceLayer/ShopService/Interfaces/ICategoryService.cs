using ServiceLayer.ShopService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ShopService.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryListDto> GetCategoryTree();
        IQueryable<CategoryListDto> GetSubCategories(int categoryId);
    }
}

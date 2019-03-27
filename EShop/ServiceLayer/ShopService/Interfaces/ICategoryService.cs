using ServiceLayer.ShopService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ShopService.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryListDto>> GetCategoryTree();
        IQueryable<CategoryListDto> GetSubCategories(int categoryId);
    }
}

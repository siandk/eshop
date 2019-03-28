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
        //List<CategoryListDto> GetSubCategories(int categoryId);
        Task<List<CategoryListDto>> GetCategoryTree();
    }
}

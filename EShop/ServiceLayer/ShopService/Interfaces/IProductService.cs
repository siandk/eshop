using ServiceLayer.ShopService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ShopService.Interfaces
{
    public interface IProductService
    {
        IQueryable<ProductListDto> GetProducts();
        IQueryable<ProductListDto> GetProductsByCategory(int categoryId);
        Task<ProductDetailDto> GetProductById(int productId);
    }
}

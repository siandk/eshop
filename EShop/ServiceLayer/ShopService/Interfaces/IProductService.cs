using ServiceLayer.ShopService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ShopService.Interfaces
{
    public interface IProductService
    {
        IQueryable<ProductListDto> GetProducts();
        IQueryable<ProductListDto> GetProductsByCategory(int categoryId);
        ProductDetailDto GetProductById(int productId);
    }
}

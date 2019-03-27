using DataLayer.Entities;
using ServiceLayer.ShopService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ShopService.QueryObjects
{
    public static class ProductDtoSelect
    {
        public static IQueryable<ProductListDto> MapProductToListDto(this IQueryable<Product> products)
        {
            return products.Select(p => new ProductListDto
            {
                ProductId = p.ProductId,
                CategoryId = p.CategoryId,
                Name = p.Name,
                Price = p.UnitPrice

            });
        }
        public static IQueryable<ProductDetailDto> MapProductToDetailDto(this IQueryable<Product> products)
        {
            return products.Select(p => new ProductDetailDto
            {
                ProductId = p.ProductId,
                Manufacturer = p.Manufacturer.Name,
                Category = p.Category.Name,
                Name = p.Name,
                Description = p.Description,
                Price = p.UnitPrice
            });
        }
    }
}

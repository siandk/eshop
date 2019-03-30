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
    public static class ProductDtoSelect
    {
        public async static Task<List<ProductListDto>> MapProductListDtoFromProcedure(this IQueryable<Product> products)
        {
            var productResults = await products.ToListAsync();

            return productResults.Select(p => new ProductListDto
            {
                ProductId = p.ProductId,
                CategoryId = p.CategoryId,
                Description = p.Description,
                Name = p.Name,
                Price = p.UnitPrice,
                ManufacturerId = p.ManufacturerId
            }).ToList();
        }
        public static IQueryable<ProductListDto> MapProductListDto(this IQueryable<Product> products)
        {
            return products.Select(p => new ProductListDto
            {
                ProductId = p.ProductId,
                CategoryId = p.CategoryId,
                Description = p.Description,
                Name = p.Name,
                Price = p.UnitPrice,
                ManufacturerId = p.ManufacturerId
            });
        }
        public static IQueryable<ProductDetailDto> MapProductDetailDto(this IQueryable<Product> products)
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

using DataLayer.Entities;
using ServiceLayer.ShopService.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ServiceLayer.ShopService.QueryObjects
{
    public enum ProductsFilterBy
    {
        [Display(Name = "By Name...")]
        ByName,
        [Display(Name = "By Manufacturer...")]
        ByManufacturer,
        [Display(Name = "Price higher than...")]
        ByPriceUp,
        [Display(Name = "Price lower than...")]
        ByPriceDown
    }
    public enum ProductsOrderBy
    {
        [Display(Name = "Name")]
        SimpleOrder = 0,
        [Display(Name = "Price ↑")]
        ByPriceAsc,
        [Display(Name = "Price ↓")]
        ByPriceDesc
    }
    public static class ProductSelectOrderFilter
    {
        // Map to Dto
        public static IQueryable<ProductDto> MapProductDto(this IQueryable<Product> products)
        {
            return products.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                Description = p.Description,
                Published = p.Published,
                Featured = p.Featured,
                Summary = p.Summary,
                Name = p.Name,
                UnitPrice = p.UnitPrice,
                ManufacturerId = p.ManufacturerId,
                ManufacturerName = p.Manufacturer.Name,
                ImageUrl = p.ImageUrl
            });
        }
        public static IQueryable<ProductDto> ProductFilterBy(this IQueryable<ProductDto> products, ProductsFilterBy filterBy, string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue))
            {
                return products;
            }
            switch (filterBy)
            {
                case ProductsFilterBy.ByName:
                    return products.Where(p => p.Name.Contains(filterValue));
                case ProductsFilterBy.ByManufacturer:
                    return products.Where(p => p.ManufacturerName.Contains(filterValue));
                case ProductsFilterBy.ByPriceUp:
                    return products.Where(p => p.UnitPrice >= decimal.Parse(filterValue));
                case ProductsFilterBy.ByPriceDown:
                    return products.Where(p => p.UnitPrice <= decimal.Parse(filterValue));
                default:
                    return products;
            }
        }
        public static IQueryable<ProductDto> ProductOrderBy(this IQueryable<ProductDto> products, ProductsOrderBy orderBy)
        {
            switch (orderBy)
            {
                case ProductsOrderBy.SimpleOrder:
                    return products.OrderBy(p => p.Name);
                case ProductsOrderBy.ByPriceAsc:
                    return products.OrderBy(p => p.UnitPrice);
                case ProductsOrderBy.ByPriceDesc:
                    return products.OrderByDescending(p => p.UnitPrice);
                default:
                    return products;
            }
        }
    }
}

using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;
using ServiceLayer.ShopService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ShopService.Concrete
{
    public class ProductService : IProductService
    {
        private readonly ShopContext _context;

        public ProductService(ShopContext context)
        {
            _context = context;
        }
        public IQueryable<ProductListDto> GetProducts()
        {
            return _context.Products.MapProductToListDto();
        }
        public IQueryable<ProductListDto> GetProductsByCategory(int categoryId)
        {
            return _context.Products
                .Where(p => p.CategoryId == categoryId)
                .MapProductToListDto();
        }
        public ProductDetailDto GetProductById(int productId)
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .Where(p => p.ProductId == productId)
                .MapProductToDetailDto()
                .FirstOrDefault();
        }

    }
}

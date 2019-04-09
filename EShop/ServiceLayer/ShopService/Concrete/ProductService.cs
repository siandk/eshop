using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;
using ServiceLayer.ShopService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ShopService.Concrete
{
    public class ProductService : GenericService, IProductService
    {
        public ProductService(ShopContext context) : base(context)
        {
        }
        public IQueryable<ProductDto> GetProducts(int? categoryId = null)
        {
            if (categoryId.HasValue)
            {
                return GetProductsByCategory(categoryId.Value).MapProductDto();
            }
            else
            {
                return GetAllProducts().MapProductDto();
            }
        }
        private IQueryable<Product> GetAllProducts()
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .AsNoTracking();
        }
        private IQueryable<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Categories
                    .Include(c => c.Products)
                    .ThenInclude(p => p.Manufacturer)
                    .Where(c => c.ParentPath.Contains($"/{categoryId}/") || c.CategoryId == categoryId)
                    .SelectMany(c => c.Products)
                    .AsNoTracking();
        }
        public async Task<ProductDto> GetProductById(int? productId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .MapProductDto()
                .FirstOrDefaultAsync(p => p.ProductId == productId);
        }
        public IQueryable<ProductSupplierPrice> GetProductPrices(int? productId = null)
        {
            var productPrices = _context.Products
                        .Include(p => p.ProductSupplierPrices)
                        .ThenInclude(ps => ps.Supplier)
                        .SelectMany(p => p.ProductSupplierPrices)
                        .AsNoTracking();
            return !productId.HasValue ? productPrices : productPrices.Where(ps => ps.ProductId == productId.Value);

        }
        public IQueryable<Manufacturer> GetProductManufacturers()
        {
            return _context.Products
                            .Where(p => p.ManufacturerId != null)
                            .Include(p => p.Manufacturer)
                            .Select(p => p.Manufacturer)
                            .Distinct()
                            .AsNoTracking();
        }
    }
}

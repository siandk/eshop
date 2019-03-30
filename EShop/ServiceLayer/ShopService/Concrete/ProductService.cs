using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;
using ServiceLayer.ShopService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _context.Products.MapProductListDto();
        }
        public async Task<List<ProductListDto>> GetProductsByCategory(int categoryId)
        {
            return await _context.Products.FromSql("sp_GetCategoryProducts @p0", categoryId)
                .MapProductListDtoFromProcedure();
        }
        public async Task<ProductDetailDto> GetProductById(int productId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .Where(p => p.ProductId == productId)
                .MapProductDetailDto()
                .FirstOrDefaultAsync();
        }

    }
}

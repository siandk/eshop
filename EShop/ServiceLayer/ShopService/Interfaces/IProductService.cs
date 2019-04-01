using DataLayer.Entities;
using ServiceLayer.ShopService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ShopService.Interfaces
{
    public interface IProductService : IGenericService
    {
        IQueryable<ProductDto> GetProducts(int? categoryId = null);
        Task<ProductDto> GetProductById(int? productId);
        IQueryable<ProductSupplierPrice> GetProductPrices(int? productId = null);
        IQueryable<Manufacturer> GetProductManufacturers();
    }
}

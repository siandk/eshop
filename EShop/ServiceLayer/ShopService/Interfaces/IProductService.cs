﻿using DataLayer.Entities;
using ServiceLayer.ShopService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ShopService.Interfaces
{
    public interface IProductService
    {
        IQueryable<ProductDto> GetProducts(int? categoryId);
        Task<ProductDto> GetProductById(int? productId);
        IQueryable<ProductSupplierPrice> GetProductPrices(int? productId);
        Task Create<T>(T model) where T : class;
        Task Update<T>(T model) where T : class;
        Task Delete<T>(T model) where T : class;
    }
}

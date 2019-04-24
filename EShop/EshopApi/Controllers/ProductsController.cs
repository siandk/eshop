using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using EshopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;

namespace EshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<PaginatedList<ProductDto>>> Get(bool featured = false, int? categoryId = null,
                                                              string name = null, int pageSize = 4, int pageNum = 1, string orderBy = null)
        {
            IQueryable<ProductDto> products = categoryId.HasValue
                                              ? _productService.GetProducts(categoryId.Value).Where(p => p.Published == true)
                                              : _productService.GetProducts().Where(p => p.Published == true);
            if (featured)
            {
                products = products.Where(p => p.Featured == true);
            }
            if (!string.IsNullOrEmpty(name))
            {
                products = products.Where(p => p.Name.Contains(name));
            }
            switch (orderBy)
            {
                case "priceAsc":
                    products = products.OrderBy(p => p.UnitPrice);
                    break;
                case "priceDesc":
                    products = products.OrderByDescending(p => p.UnitPrice);
                    break;
                default:
                    products = products.OrderBy(p => p.Name);
                    break;
            }
            return Ok(await PaginatedList<ProductDto>.CreateAsync(products, pageNum, pageSize));
        }
        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductDto>> Get(int productId)
        {
            ProductDto product = await _productService.GetProductById(productId);
            return product != null && product.Published == true ? Ok(product) : StatusCode(StatusCodes.Status404NotFound, "Product not found");
        }
        [HttpPut]
        public async Task<ActionResult<ProductDto>> Put(ProductDto productDto)
        {
            await _productService.Update(productDto.MapToProduct());
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post(ProductDto productDto)
        {
            Product product = productDto.MapToProduct();
            await _productService.Create(product);
            return Created($"/api/products/{product.ProductId}", product);
        }
        [HttpDelete("{productId}")]
        public async Task<ActionResult> Delete(int productId)
        {
            ProductDto product = await _productService.GetProductById(productId);
            if ( product == null )
            {
                return StatusCode(StatusCodes.Status404NotFound, "Product not found");
            }
            await _productService.Delete(product.MapToProduct());
            return Ok();
        }
    }
}
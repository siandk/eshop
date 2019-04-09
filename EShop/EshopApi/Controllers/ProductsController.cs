using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
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
        public async Task<ActionResult<List<ProductDto>>> Get()
        {
            List<ProductDto> products = await _productService.GetProducts().Where(p => p.Published == true).ToListAsync();
            return Ok(products);
        }
        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductDto>> Get(int productId)
        {
            ProductDto product = await _productService.GetProductById(productId);
            return product != null && product.Published == true ? Ok(product) : StatusCode(StatusCodes.Status404NotFound, "Product not found");
        }
        [HttpGet("search")]
        public async Task<ActionResult<List<ProductDto>>> Get(string search)
        {
            List<ProductDto> products = await _productService.GetProducts().Where(p => p.Name.Contains(search)).ToListAsync();
            return Ok(products);
        }
        [HttpPut]
        public async Task<ActionResult> Put(ProductDto productDto)
        {
            await _productService.Update(productDto.MapToProduct());
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post(ProductDto productDto)
        {
            Product product = productDto.MapToProduct();
            await _productService.Create(product);
            return Created($"/api/order/{product.ProductId}", product);
        }
        [HttpDelete("{productId}")]
        public async Task<ActionResult> Delete(int productId)
        {
            ProductDto product = await _productService.GetProductById(productId);
            if ( product == null )
            {
                return StatusCode(StatusCodes.Status404NotFound, "Product not found");
            }
            await _productService.Delete(product);
            return Ok();
        }
    }
}
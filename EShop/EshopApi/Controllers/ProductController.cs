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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
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
            return product.Published == true ? Ok(product) : StatusCode(StatusCodes.Status404NotFound, "Product not found");
        }
        [HttpGet("search")]
        public async Task<ActionResult<List<ProductDto>>> Get(string search)
        {
            List<ProductDto> products = await _productService.GetProducts().Where(p => p.Name.Contains(search)).ToListAsync();
            return Ok(products);
        }
    }
}
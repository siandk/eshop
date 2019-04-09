using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using EshopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Interfaces;

namespace EshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> Get()
        {
            List<CategoryDto> categories = await _categoryService.GetCategoryTree().Select(c => new CategoryDto(c)).ToListAsync();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Post(CategoryDto category)
        {
            await _categoryService.Create(category.ToCategory());
            return Created("/api/categories", category);
        }
        [HttpPut]
        public async Task<ActionResult<CategoryDto>> Put(CategoryDto category)
        {
            await _categoryService.Update(category.ToCategory());
            return Ok();
        }
        [HttpDelete("{categoryId}")]
        public async Task<ActionResult> Delete(int categoryId)
        {
            Category category = await _categoryService.GetCategoryById(categoryId).FirstOrDefaultAsync();
            if (category == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Category Not Found");
            }
            await _categoryService.Delete(category);
            return Ok();
        }
    }
}
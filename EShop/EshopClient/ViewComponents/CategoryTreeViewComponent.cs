using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopClient.ViewComponents
{
    public class CategoryTreeViewComponent : ViewComponent
    {
        private readonly ICategoryService _service;
        public CategoryTreeViewComponent(ICategoryService service)
        {
            _service = service;
        }
        List<Category> Categories { get; set; }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Categories = await _service.GetCategoryTree().ToListAsync();
            return View(Categories);
        }
    }
}

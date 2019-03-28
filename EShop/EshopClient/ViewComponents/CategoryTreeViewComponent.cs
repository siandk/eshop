using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _service.GetCategoryTree();
            return View(categories);
        }
    }
}

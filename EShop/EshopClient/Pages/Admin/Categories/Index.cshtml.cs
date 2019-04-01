using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;
using ServiceLayer.ShopService.QueryObjects;

namespace EshopClient.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService _service;

        public IndexModel(ICategoryService service)
        {
            _service = service;
        }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public List<Category> Categories { get; set; }


        public async Task OnGetAsync()
        {
            var categories = _service.GetCategoryTree();
            if (!string.IsNullOrEmpty(Name))
            {
                categories = categories.Where(c => c.Name.Contains(Name));
            }
            Categories = await categories.ToListAsync();
        }
    }
}

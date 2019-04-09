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

namespace EshopClient.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryService _service;


        public CreateModel(ICategoryService categoryService)
        {
            _service = categoryService;
        }


        [BindProperty]
        public Category Category { get; set; }
        public SelectList ParentCategory => new SelectList(_service.GetCategoryTree().ToList(), "CategoryId", "Name");

        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // Attach parent category entity, to make sure the parentpath is set correctly
            if (Category.ParentCategoryId != null)
            {
                Category.ParentCategory = _service.GetCategoryById(Category.ParentCategoryId).First();
            }
            await _service.Create(Category);

            return RedirectToPage("./Index");
        }
    }
}
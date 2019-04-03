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
    public class EditModel : PageModel
    {
        private readonly ICategoryService _service;


        public EditModel(ICategoryService categoryService)
        {
            _service = categoryService;
        }

        [BindProperty]
        public Category Category { get; set; }

        public SelectList ParentCategory { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ParentCategory = new SelectList(await _service.GetCategoryTree()
                                                    .Where(c => (!c.ParentPath.Contains($"/{id}/") || c.ParentPath == null) && c.CategoryId != id)
                                                    .ToListAsync(), "CategoryId", "Name");
            Category = await _service.GetCategoryById(id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _service.Update<Category>(Category);
            return RedirectToPage("./Index");
        }
    }
}

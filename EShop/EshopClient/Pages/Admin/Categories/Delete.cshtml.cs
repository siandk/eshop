using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;

namespace EshopClient.Pages.Admin.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryService _service;
        private readonly IToastNotification _toastNotification;

        public DeleteModel(ICategoryService service, IToastNotification toastNotification)
        {
            _service = service;
            _toastNotification = toastNotification;
        }

        [BindProperty]
        public Category Category { get; set; }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = _service.GetCategoryById(id).FirstOrDefault();

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = _service.GetCategoryById(id).FirstOrDefault();

            if (Category != null)
            {
                try
                {
                    await _service.Delete(Category);
                }
                catch (DbUpdateException)
                {
                    _toastNotification.AddErrorToastMessage("You cannot delete a category that contains products");
                    return RedirectToPage("./Delete", new { id });
                }
            }

            return RedirectToPage("./Index");
        }
    }
}

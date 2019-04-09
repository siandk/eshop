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

namespace EshopClient.Pages.Admin.Suppliers
{
    public class EditModel : PageModel
    {
        private readonly ISupplierService _service;


        public EditModel(ISupplierService service)
        {
            _service = service;
        }

        [BindProperty]
        public Supplier Supplier { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Supplier = await _service.GetSupplierById(id);

            if (Supplier == null)
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

            await _service.Update(Supplier);
            return RedirectToPage("./Index");
        }
    }
}

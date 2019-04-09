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
    public class CreateModel : PageModel
    {
        private readonly ISupplierService _service;


        public CreateModel(ISupplierService Service)
        {
            _service = Service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Supplier Supplier { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _service.Create(Supplier);

            return RedirectToPage("./Index");
        }
    }
}
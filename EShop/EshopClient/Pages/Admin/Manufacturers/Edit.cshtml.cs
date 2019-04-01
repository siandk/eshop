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

namespace EshopClient.Pages.Admin.Manufacturers
{
    public class EditModel : PageModel
    {
        private readonly IManufacturerService _service;


        public EditModel(IManufacturerService manufacturerService)
        {
            _service = manufacturerService;
        }

        [BindProperty]
        public Manufacturer Manufacturer { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacturer = await _service.GetManufacturerById(id);

            if (Manufacturer == null)
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

            await _service.Update<Manufacturer>(Manufacturer);
            return RedirectToPage("./Index");
        }

        //private bool ProductDtoExists(int id)
        //{
        //    return _context.ProductDto.Any(e => e.ProductId == id);
        //}
    }
}

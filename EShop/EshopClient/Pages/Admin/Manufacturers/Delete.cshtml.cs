using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;

namespace EshopClient.Pages.Admin.Manufacturers
{
    public class DeleteModel : PageModel
    {
        private readonly IManufacturerService _service;

        public DeleteModel(IManufacturerService service)
        {
            _service = service;
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacturer = await _service.GetManufacturerById(id);

            if (Manufacturer != null)
            {
                await _service.Delete<Manufacturer>(Manufacturer);
            }

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Entities;
using ServiceLayer.ShopService.Interfaces;
using ServiceLayer.ShopService.Dto;

namespace EshopClient.Pages.Shop
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _service;

        public DetailsModel(IProductService service)
        {
            _service = service;
        }

        public ProductDto Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _service.GetProductById(id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

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

namespace EshopClient.Pages.Admin.Manufacturers
{
    public class IndexModel : PageModel
    {
        private readonly IManufacturerService _service;

        public IndexModel(IManufacturerService service)
        {
            _service = service;
        }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }


        public async Task OnGetAsync()
        {
            var manufacturers = _service.GetManufacturers();
            if (!string.IsNullOrEmpty(Name))
            {
                manufacturers = manufacturers.Where(m => m.Name.Contains(Name));
            }
            Manufacturers = await manufacturers.ToListAsync();
        }
    }
}

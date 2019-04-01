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

namespace EshopClient.Pages.Admin.Suppliers
{
    public class IndexModel : PageModel
    {
        private readonly ISupplierService _service;

        public IndexModel(ISupplierService service)
        {
            _service = service;
        }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public List<Supplier> Suppliers { get; set; }


        public async Task OnGetAsync()
        {
            var suppliers = _service.GetSuppliers();
            if (!string.IsNullOrEmpty(Name))
            {
                suppliers = suppliers.Where(m => m.Name.Contains(Name));
            }
            Suppliers = await suppliers.ToListAsync();
        }
    }
}

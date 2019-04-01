using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;
using ServiceLayer.ShopService.QueryObjects;

namespace EshopClient.Pages.Admin.Currencies
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _service;

        public IndexModel(IProductService service)
        {
            _service = service;
        }

        [BindProperty(SupportsGet = true)]
        public int? CategoryId { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ManufacturerName { get; set; }

        public List<ProductDto> Products { get; set; }
        public SelectList Manufacturers { get; set; }


        public async Task OnGetAsync()
        {
            var products = _service.GetProducts(CategoryId);
            if (!string.IsNullOrEmpty(Name))
            {
                products = products.ProductFilterBy(ProductsFilterBy.ByName, Name);
            }
            if (!string.IsNullOrEmpty(ManufacturerName))
            {
                products = products.ProductFilterBy(ProductsFilterBy.ByManufacturer, ManufacturerName);
            }
            Products = await products.ToListAsync();
            if (Products.Any(p => p.ManufacturerName != null))
            {
                Manufacturers = new SelectList(Products
                                                .Where(p => p.ManufacturerName != null)
                                                .Select(p => new SelectListItem() { Text = p.ManufacturerName, Value = p.ManufacturerName }));
            }
        }
    }
}

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
using ServiceLayer.ShopService.QueryObjects;
using Microsoft.AspNetCore.Mvc.Rendering;
using EshopClient.Data;

namespace EshopClient.Pages.Shop
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

        public PaginatedList<ProductDto> Products { get;set; }
        public SelectList Manufacturers { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? PageNum { get; set; }

        public async Task OnGetAsync()
        {
            var products = _service.GetProducts(CategoryId);
            if (!string.IsNullOrEmpty(Name))
            {
                PageNum = 1;
                products = products.ProductFilterBy(ProductsFilterBy.ByName, Name);
            }
            if (!string.IsNullOrEmpty(ManufacturerName))
            {
                products = products.ProductFilterBy(ProductsFilterBy.ByManufacturer, ManufacturerName);
            }
            Products = await PaginatedList<ProductDto>.CreateAsync(products, PageNum ?? 1, 3);
            var manuf = _service.GetProductManufacturers().ToList();
            Manufacturers = new SelectList(_service.GetProductManufacturers().ToList(), "Name", "Name");
        }
    }
}

﻿using System;
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

namespace EshopClient.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IManufacturerService _manufacturerService;
        private readonly ISupplierService _supplierService;


        public EditModel(ISupplierService supplierService, IProductService productService, ICategoryService categoryService, IManufacturerService manufacturerService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _manufacturerService = manufacturerService;
            _supplierService = supplierService;
        }

        [BindProperty]
        public ProductDto ProductDto { get; set; }
        public List<ProductSupplierPrice> ProductPrices { get; set; }
        [BindProperty]
        public ProductSupplierPrice ProductPrice { get; set; }
        public SelectList Suppliers { get; set; }
        public SelectList Categories => new SelectList(_categoryService.GetCategoryTree().ToList(), "CategoryId", "Name");
        public SelectList Manufacturers => new SelectList(_manufacturerService.GetManufacturers().ToList(), "ManufacturerId", "Name");
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductPrice = new ProductSupplierPrice() { ProductId = id.Value };
            ProductDto = await _productService.GetProductById(id);
            ProductPrices = await _productService.GetProductPrices(id).Include(ps => ps.Supplier).ToListAsync();
            var suppliers = await _supplierService.GetSuppliers().Except(_productService.GetProductPrices(id).Select(ps => ps.Supplier)).ToListAsync();
            Suppliers = new SelectList(suppliers, "SupplierId", "Name");

            if (ProductDto == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostPriceCreateAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            await _productService.Create<ProductSupplierPrice>(ProductPrice);
            return RedirectToPage("./Edit", new { id = ProductPrice.ProductId });
        }
        public async Task<IActionResult> OnPostPriceDeleteAsync(int supplierId, int productId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var productPrice = await _productService.GetProductPrices().Where(p => p.SupplierId == supplierId && p.ProductId == productId).FirstOrDefaultAsync();

            if (productPrice == null)
            {
                return Page();
            }
            await _productService.Delete<ProductSupplierPrice>(productPrice);
            return RedirectToPage("./Edit", new { id = productPrice.ProductId });
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productService.Update<Product>(ProductDto.MapToProduct());
            return RedirectToPage("./Index");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;

namespace EshopClient.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IList<ProductListDto> Products { get; set; }
        private readonly IProductService _productService;
        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> OnGetAsync(int? categoryId)
        {
            if (!categoryId.HasValue)
            {
                Products = await _productService.GetProducts().ToListAsync();
            }
            else
            {
                Products = await _productService.GetProductsByCategory(categoryId.Value).ToListAsync();
            }
            return Page();
        }
    }
}

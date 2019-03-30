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
        public string SearchString { get; set; }
        public IList<ProductListDto> Products { get;set; }

        public async Task OnGetAsync()
        {
            if (CategoryId.HasValue)
            {
                Products = await _service.GetProductsByCategory(CategoryId.Value);
            }
            else
            {
                Products = await _service.GetProducts().ToListAsync();
            }
            if (SearchString != null)
            {
                Products = Products.Where(p => p.Name.Contains(SearchString)).ToList();
            }
        }
    }
}

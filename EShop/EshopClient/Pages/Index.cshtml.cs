using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopClient.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;

namespace EshopClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _service;
        [BindProperty(SupportsGet = true)]
        public int? PageNum { get; set; }
        public IndexModel(IProductService service)
        {
            _service = service;
        }
        public PaginatedList<ProductDto> FeaturedProducts { get; set; }
        public async Task OnGetAsync()
        {
            FeaturedProducts = await PaginatedList<ProductDto>.CreateAsync(_service.GetProducts().Where(p => p.Featured == true), PageNum ?? 1, 4);
        }
    }
}

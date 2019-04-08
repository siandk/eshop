using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;

namespace EshopClient.Pages.Admin.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _service;

        public IndexModel(IOrderService service)
        {
            _service = service;
        }
        public List<OrderDto> Orders { get; set; }
        public async Task OnGetAsync()
        {
            Orders = await _service.GetOrders().ToListAsync();
        }
    }
}
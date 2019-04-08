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
    public class EditModel : PageModel
    {

        private readonly IOrderService _service;

        public EditModel(IOrderService service)
        {
            _service = service;
        }
        public OrderDto Order { get; set; }
        public async Task OnGetAsync(int orderId)
        {
            Order = await _service.GetOrderById(orderId).FirstOrDefaultAsync();
        }
    }
}
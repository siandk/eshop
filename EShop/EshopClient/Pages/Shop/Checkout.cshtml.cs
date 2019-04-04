using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using EshopClient.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.ShopService.Dto;

namespace EshopClient.Pages.Shop
{
    public class CheckoutModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        public CheckoutModel(ICustomerService customerService, IOrderService orderService)
        {
            _customerService = customerService;
            _orderService = orderService;
        }
        [BindProperty]
        public Customer Customer { get; set; }
        public OrderDto Order { get; set; }
        public void OnGet()
        {
            if (HttpContext.Session.Get("order") != null)
            {
                Order = HttpContext.Session.Get<OrderDto>("order");
            }
            if (User.Identity.IsAuthenticated)
            {

            }
        }
    }
}
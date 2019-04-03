using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopClient.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.ShopService.Dto;

namespace EshopClient.Pages.Shop
{
    public class CheckoutModel : PageModel
    {
        public OrderDto Order { get; set; }
        public void OnGet()
        {
            if (HttpContext.Session.Get("order") != null)
            {
                Order = HttpContext.Session.Get<OrderDto>("order");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using EshopClient.Areas.Identity.Data;
using EshopClient.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ServiceLayer.ShopService.Dto;
using ServiceLayer.ShopService.Interfaces;

namespace EshopClient.Pages.Shop
{
    public class CheckoutModel : PageModel
    {
        private readonly IToastNotification _toastNotification;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly UserManager<EshopUser> _userManager;
        public CheckoutModel(IToastNotification toastNotification, ICustomerService customerService, IOrderService orderService, UserManager<EshopUser> userManager)
        {
            _toastNotification = toastNotification;
            _customerService = customerService;
            _orderService = orderService;
            _userManager = userManager;
        }
        [BindProperty]
        public Customer Customer { get; set; }
        public OrderDto Order { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var sessionOrder = HttpContext.Session.Get<OrderDto>("order");
            if (sessionOrder != null && sessionOrder.OrderLines.Count > 0)
            {

                if (string.IsNullOrEmpty(Customer.UserGuid) && User.Identity.IsAuthenticated)
                {
                    Customer.UserGuid = _userManager.GetUserId(User);
                    Customer.ContactInfo.Email = User.Identity.Name;
                    await _customerService.Create<Customer>(Customer);
                }
                if (!User.Identity.IsAuthenticated)
                {
                    await _customerService.Create<Customer>(Customer);
                }
                await _orderService.CheckoutOrder(sessionOrder, Customer);
            }
            _toastNotification.AddSuccessToastMessage("Thank you for your order!");
            HttpContext.Session.Set<OrderDto>("order", new OrderDto());
            return RedirectToPage("/Shop/Index");
        }
        public async Task OnGetAsync()
        {
            if (HttpContext.Session.Get("order") != null)
            {
                Order = HttpContext.Session.Get<OrderDto>("order");
            }
            else
            {
                RedirectToPage("/Shop/Index");
            }
            if (User.Identity.IsAuthenticated)
            {
                Customer = await _customerService.GetByGuid(_userManager.GetUserId(User)).Include(c => c.ContactInfo).FirstOrDefaultAsync();
                if (Customer == null)
                {
                    Customer = new Customer()
                    {
                        ContactInfo = new ContactInfo()
                    };
                }
            }
            else
            {
                Customer = new Customer()
                {
                    ContactInfo = new ContactInfo()
                };
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.ShopService.Dto;
using EshopClient.Data;
using ServiceLayer.ShopService.Interfaces;
using NToastNotify;

namespace EshopClient.Pages.Shop
{
    public class CartModel : PageModel
    {
        private readonly IToastNotification _toastNotification;
        private readonly IProductService _service;
        public CartModel(IProductService service, IToastNotification toastNotification)
        {
            _service = service;
            _toastNotification = toastNotification;
        }
        [BindProperty]
        public int ProductId { get; set; }
        [BindProperty]
        public OrderDto Order { get; set; }
        public void OnGet()
        {
            if (HttpContext.Session.Get("order") != null)
            {
                Order = HttpContext.Session.Get<OrderDto>("order");
            }
        }
        public async Task<IActionResult> OnPostRemoveAsync(int ProductId)
        {
            ProductDto product = await _service.GetProductById(ProductId);
            if (product == null)
            {
                _toastNotification.AddErrorToastMessage("An error occurred. The product was not found");
                return RedirectToPage("/Shop/Index");
            }
            if (HttpContext.Session.Get("order") != null)
            {
                OrderDto order = HttpContext.Session.Get<OrderDto>("order");
                order.OrderLines.RemoveAll(l => l.ProductId == product.ProductId);
                HttpContext.Session.Set("order", order);
            }
            return RedirectToPage("/Shop/Cart");
        }
        public async Task<IActionResult> OnPostAdd(int ProductId)
        {
            ProductDto product = await _service.GetProductById(ProductId);
            if (product == null)
            {
                _toastNotification.AddErrorToastMessage("An error occurred. The product was not found");
                return Partial("_NotificationPartial");
            }
            // If an order is already present in the Session, add a new line or increase quantity
            if (HttpContext.Session.Get("order") != null)
            {
                OrderDto order = HttpContext.Session.Get<OrderDto>("order");
                // Search for orderline with the product id, and increase quantity
                OrderLineDto orderLine = order.OrderLines.Find(l => l.ProductId == ProductId);
                if (orderLine != null)
                {
                    orderLine.Quantity += 1;
                }
                // Else add a new line
                else
                {
                    order.OrderLines.Add(new OrderLineDto()
                    {
                        ProductId = ProductId,
                        ProductName = product.Name,
                        ProductUnitPrice = product.UnitPrice,
                        Quantity = 1
                    });
                }
                HttpContext.Session.Set("order", order);
            }
            // No order found in session, create a new
            else
            {
                OrderDto order = new OrderDto();
                order.OrderLines.Add(new OrderLineDto()
                {
                    ProductId = ProductId,
                    ProductName = product.Name,
                    Quantity = 1,
                    ProductUnitPrice = product.UnitPrice
                });
                HttpContext.Session.Set("order", order);
            }
            _toastNotification.AddSuccessToastMessage($"{product.Name} added to cart");
            return Partial("_NotificationPartial");
        }
    }
}
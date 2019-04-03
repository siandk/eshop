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

namespace EshopClient.Pages.Shop
{
    public class CartModel : PageModel
    {
        private readonly IProductService _service;
        public CartModel(IProductService service)
        {
            _service = service;
        }
        [BindProperty]
        public int ProductId { get; set; }
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
                return RedirectToPage();
            }
            if (HttpContext.Session.Get("order") != null)
            {
                OrderDto order = HttpContext.Session.Get<OrderDto>("order");
                order.OrderLines.RemoveAll(l => l.ProductId == product.ProductId);
                HttpContext.Session.Set<OrderDto>("order", order);
            }
            return RedirectToPage("/Shop/Cart");
        }
        public async Task OnPostAdd(int ProductId)
        {
            ProductDto product = await _service.GetProductById(ProductId);
            if (product == null)
            {
                return;
            }
            if (HttpContext.Session.Get("order") != null)
            {
                OrderDto order = HttpContext.Session.Get<OrderDto>("order");
                if (order.OrderLines.Find(l => l.ProductId == ProductId) != null)
                {
                    order.OrderLines.Find(l => l.ProductId == ProductId).Quantity += 1;
                }
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
                HttpContext.Session.Set<OrderDto>("order", order);
            }
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
                HttpContext.Session.Set<OrderDto>("order", order);
            }
        }
    }
}
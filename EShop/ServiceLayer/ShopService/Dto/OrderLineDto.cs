using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ShopService.Dto
{
    public class OrderLineDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal ProductUnitPrice { get; set; } // Hidden in view
        public decimal LinePrice { get; set; }
        public OrderLine MapToLine()
        {
            return new OrderLine()
            {
                LineQuantity = Quantity,
                ProductId = ProductId
            };
        }
    }
}

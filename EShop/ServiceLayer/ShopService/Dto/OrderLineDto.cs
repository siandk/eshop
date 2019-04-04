using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.ShopService.Dto
{
    public class OrderLineDto
    {
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Product")]
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal ProductUnitPrice { get; set; } // Hidden in view
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal LinePrice
        {
            get
            {
                return ProductUnitPrice * Quantity;
            }
            set { }
        }
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

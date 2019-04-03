using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Quantity")]
        public decimal LineQuantity { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal LinePrice
        {
            get
            {
                if (Product != null)
                {
                    return Product.UnitPrice * LineQuantity;
                }
                else
                {
                    return 0;
                }
            }
            protected set { }
        }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Cost Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitCostPrice { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}

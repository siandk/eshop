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
        public int UomId { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal LineQuantity { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal LinePrice
        {
            get
            {
                return Product.UnitPrice * LineQuantity * Uom.UnitMultiplier;
            }
            protected set { }
        }
        public UnitOfMeasure Uom { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}

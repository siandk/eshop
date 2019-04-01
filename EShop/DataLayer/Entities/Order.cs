using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataLayer.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal AmountTotal
        {
            get
            {
                if (OrderLines.Count > 0)
                {
                    return OrderLines.Sum(ol => ol.LinePrice);
                }
                else
                {
                    return 0;
                }
            }
            protected set { }
        }
        [MaxLength(150)]
        public string OrderNote { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}

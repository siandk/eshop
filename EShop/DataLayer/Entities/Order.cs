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
        public int CustomerId { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Order Total")]
        [Column(TypeName = "decimal(18,2)")]
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
        [Display(Name = "Notes")]
        public string OrderNote { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}

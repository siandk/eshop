using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}

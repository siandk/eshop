using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class ProductSupplierPrice
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
    }
}

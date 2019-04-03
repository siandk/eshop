using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class ProductSupplierPrice
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
    }
}

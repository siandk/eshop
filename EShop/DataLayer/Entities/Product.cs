using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        public int? ManufacturerId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal UnitPrice { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public bool Published { get; set; }
        public bool Featured { get; set; }
        [MaxLength(50)]
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public List<ProductSupplierPrice> ProductSupplierPrices { get; set; }
    }
}

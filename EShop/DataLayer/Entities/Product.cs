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
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }

        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}

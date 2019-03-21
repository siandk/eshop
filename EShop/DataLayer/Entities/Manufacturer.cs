using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}

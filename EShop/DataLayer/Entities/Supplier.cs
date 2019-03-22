using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public int? ContactInfoId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public List<ProductSupplierPrice> ProductSupplierPrices { get; set; }
    }
}

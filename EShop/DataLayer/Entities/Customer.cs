using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int? ContactInfoId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        // Identity user ID
        public string UserGuid { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public List<Order> Orders { get; set; }
    }
}

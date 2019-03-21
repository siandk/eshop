using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class ContactInfo
    {
        public string ContactInfoId { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(50)]
        public string Street { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string Zip { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
    }
}

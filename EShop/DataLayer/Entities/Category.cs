using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}

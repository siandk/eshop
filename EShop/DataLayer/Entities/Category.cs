using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int? ParentCategoryId { get; set; }
        // Path to root category. eg. /1/5/13
        public string ParentPath { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public Category ParentCategory { get; set; }
        public List<Category> ChildCategories { get; set; }
    }
}

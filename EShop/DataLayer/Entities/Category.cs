using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class Category
    {
        public Category()
        {
            ChildCategories = new HashSet<Category>();
        }
        public int CategoryId { get; set; }
        public int? ParentCategoryId { get; set; }

        // Path to the top level category through the hierarchy
        public string ParentPath
        {
            get
            {
                if (ParentCategory != null)
                {
                   return ParentCategory.ParentPath != null
                                ? ParentCategory.ParentPath + ParentCategory.CategoryId.ToString() + "/"
                                : "/" + ParentCategory.CategoryId.ToString() + "/";
                }
                else
                {
                    return null;
                }
            }
            protected set
            {
            }
        }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Category> ChildCategories { get; set; }
    }
}

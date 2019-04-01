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
        public List<Category> ChildCategories { get; set; }
        public Category()
        {
            ChildCategories = new List<Category>();
        }
    }
}

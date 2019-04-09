using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EshopApi.Models
{
    public class CategoryDto
    {
        public CategoryDto() { }
        public CategoryDto(Category category)
        {
            CategoryId = category.CategoryId;
            Name = category.Name;
            ParentCategoryId = category.ParentCategoryId;
        }
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }

        public Category ToCategory()
        {
            return new Category()
            {
                CategoryId = CategoryId,
                Name = Name,
                ParentCategoryId = ParentCategoryId
            };
        }
    }
}

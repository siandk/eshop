using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.ShopService.Dto
{
    public class ProductDto
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public int? ManufacturerId { get; set; }
        [Display(Name = "Manufacturer")]
        public string ManufacturerName { get; set; }
        public bool Published { get; set; }
        public bool Featured { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price per unit")]
        public decimal UnitPrice { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [MaxLength(50)]
        public string Summary { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public Product MapToProduct()
        {
            return new Product()
            {
                ProductId = ProductId,
                Name = Name,
                Summary = Summary,
                CategoryId = CategoryId,
                ManufacturerId = ManufacturerId,
                Description = Description,
                UnitPrice = UnitPrice,
                Featured = Featured,
                Published = Published,
                ImageUrl = ImageUrl

            };
        }
    }
}

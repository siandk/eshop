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
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int? ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public bool Published { get; set; }
        public bool Featured { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }

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
                Published = Published

            };
        }
    }
}

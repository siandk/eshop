using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ShopService.Dto
{
    public class ProductListDto
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

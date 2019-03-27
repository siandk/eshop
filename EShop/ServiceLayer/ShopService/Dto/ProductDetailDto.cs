﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ShopService.Dto
{
    public class ProductDetailDto
    {
        public int ProductId { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}

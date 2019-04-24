using ServiceLayer.ShopService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopApi.Models
{
    public class CheckoutDto
    {
        public OrderDto Order { get; set; }
        public CustomerDto Customer { get; set; }
    }
}

using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ServiceLayer.ShopService.Dto
{
    public class OrderDto
    {
        public OrderDto()
        {
            OrderLines = new List<OrderLineDto>();
        }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public string Notes { get; set; }
        public List<OrderLineDto> OrderLines { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Total")]
        public decimal AmountTotal
        {
            get
            {
                return OrderLines != null ? OrderLines.Sum(l => l.LinePrice) : 0M;
            }
            set { }
        }
        public Order MapToOrder()
        {
            return new Order()
            {
                CustomerId = CustomerId,
                OrderDate = OrderDate,
                OrderNote = Notes,
                OrderLines = OrderLines.Select(l => l.MapToLine()).ToList()
                
            };
        }
    }
}

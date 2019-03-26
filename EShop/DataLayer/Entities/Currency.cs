using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }
        [Required]
        [MaxLength(50)]
        // Symbol to display for this currency. eg. €, $, kr.
        public string Symbol { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        // Rate according to the base currency.
        public decimal CurrencyRate { get; set; }
    }
}

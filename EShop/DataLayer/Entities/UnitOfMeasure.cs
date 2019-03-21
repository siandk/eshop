using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class UnitOfMeasure
    {
        public int UomId { get; set; }
        public int? ParentUomId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string ParentPath { get; set; }

        [Required]
        public decimal UnitMultiplier { get; set; }
        public decimal UnitDiscount { get; set; }

        public UnitOfMeasure ParentUom { get; set; }
        public List<UnitOfMeasure> ChildUoms { get; set; }
    }
}

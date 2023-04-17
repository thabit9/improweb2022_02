using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace improweb2022_02.Models
{
    [Table("Specifications")]
    public class Specifications
    {
        public Specifications()
        {          
        }

        [Key]
        public Int64 SpecificationID { get; set; }
        public string Description { get; set; }
        public string SpecificationValue { get; set; }
        public string SpecificationGroup { get; set; }
        public int GroupOrder { get; set; }
        public int DescriptionOrder { get; set; }
        public Int64 ProdID { get; set; }
        public virtual Product Product { get; set; } 

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace improweb2022_02.Models
{
    [Table("ProductGroups")]
    public partial class ProductGroups
    {
        public ProductGroups()
        {
        }
        
        [Key]
        public Int64 ProdGroupID { get; set; } 
        public string GroupName { get; set; }  
        public Byte Status { get; set; }
        public Int64 IndustryNo { get; set; }
        public bool IsComponent { get; set; }
        public bool Locked { get; set; }
        public virtual Industry Industry { get; set;}

    }
}
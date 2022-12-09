using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace improweb2022_02.Models
{
    [Table("ProductGroupTopLink")]
    public partial class ProductGroupTopLink
    {
        public ProductGroupTopLink()
        {
        }
        
        [Key]
        public Int64 ProductGroupTopLinkId { get; set; } 
        public Int64 ProductGroupTopId { get; set; }  
        public Int64 GroupHeadID { get; set; }
        
        public virtual ProductGroupTop ProductGroupTop { get; set; }
        public virtual ProductGroupHead ProductGroupHead { get; set; }

    }
}
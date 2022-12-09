using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace improweb2022_02.Models
{
    [Table("ProductGroupTop")]
    public partial class ProductGroupTop
    {
        public ProductGroupTop()
        {
            ProductGroupTopLinks = new HashSet<ProductGroupTopLink>();
        }

        [Key]
        public Int64 ProductGroupTopId { get; set; } 
        public string Name { get; set; }  
        public Int64 OrgID { get; set; }
        public int Order { get; set; }
        public bool isMain { get; set; }
        public string Header { get; set; }

        public virtual Organisation Organisation { get; set; }
        public virtual ICollection<ProductGroupTopLink> ProductGroupTopLinks { get; set; }

    }
}
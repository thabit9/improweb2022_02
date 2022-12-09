using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace improweb2022_02.Models
{
    [Table("ProductGroupHead")]
    public partial class ProductGroupHead
    {
        public ProductGroupHead()
        {
            ProdGroupLinks = new HashSet<ProdGroupLink>();
            ProductGroupTopLinks = new HashSet<ProductGroupTopLink>();
        }
        
        [Key]
        public Int64 GroupHeadID { get; set; } 
        public Int64 OrgID { get; set; }  
        public string HeadName { get; set; }
        public int HeadOrder { get; set; }
        
        public virtual Organisation Organisation { get; set;}
        public virtual ICollection<ProdGroupLink> ProdGroupLinks { get; set; }
        public virtual ICollection<ProductGroupTopLink> ProductGroupTopLinks { get; set; }

    }
}
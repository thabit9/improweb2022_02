using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace improweb2022_02.Models
{
    [Table("ProdGroupLink")]
    public partial class ProdGroupLink
    {
        public ProdGroupLink()
        {

        }
        
        [Key]
        public Int64 ProdGroupLinkID { get; set; } 
        public Int64 GroupHeadID { get; set; }  
        public string ProdGroupName { get; set; }
        
        public virtual ProductGroupHead ProductGroupHead { get; set; }

    }
}
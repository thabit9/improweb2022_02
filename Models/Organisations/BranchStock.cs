using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("BranchStock")]
    public class BranchStock
    {
        public BranchStock()
        {
            
        }
        
        public Int64 ProdID { get; set; }
        public Int64 OrgBraID { get; set; }
        public int StockCount { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual Product Product { get; set;}
        public virtual OrganisationBranch OrganisationBranch { get; set;}
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("WishList")]
    public class Wishlist
    {
        public Wishlist()
        {   
        }

        [Key]
        public Int64 WishID { get; set; }
        public DateTime CreationDate { get; set; }
        [UIHint("Currency")] 
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Int64 CustID { get; set; }
        public Int64 ProdID { get; set; }
        public Int64 OrgBranchID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        //public virtual OrganisationBranch OrganisationBranches{ get; set; }
        
    }

}
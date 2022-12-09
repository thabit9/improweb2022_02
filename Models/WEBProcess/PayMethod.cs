using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("WEBPayMethod")]
    public partial class PayMethod
    {
        public PayMethod()
        {    
            OrgPayMethods = new HashSet<OrgPayMethod>();  
        }
        
        [Key]
        public Int64 PayID { get; set; }
        public string Method { get; set; }
        public virtual ICollection<OrgPayMethod> OrgPayMethods { get; set; }
    }
}
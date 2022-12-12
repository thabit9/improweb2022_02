using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("Industry")]
    public partial class Industry
    {
        public Industry()
        {    
           //Organisations = new HashSet<Organisation>(); 
           //ProductGroups = new HashSet<ProductGroups>(); 
        }
        

        public Int64 IndustryID { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public bool Status { get; set; }
        //public virtual ICollection<Organisation> Organisations { get; set; }
        //public virtual ICollection<ProductGroups> ProductGroups { get; set; }
    }
}
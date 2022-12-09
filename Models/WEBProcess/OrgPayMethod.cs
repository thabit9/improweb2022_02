using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("WEBOrgPayMethod")]
    public class OrgPayMethod
    {
        public OrgPayMethod()
        {    
        }
        
        public Int64 PayID { get; set; }
        public Int64 OrgID { get; set; }
        public string Order { get; set; }
        public string Description { get; set; }
        
        [ForeignKey(nameof(PayID))]
        public virtual PayMethod PayMethod { get; set; }
        [ForeignKey(nameof(OrgID))]
        public virtual Organisation Organisation { get; set; }
        //public virtual OrganisationSetting OrgSetting { get; set; }
    }
}
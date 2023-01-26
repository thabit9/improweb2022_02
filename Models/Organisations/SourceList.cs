using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("SourceList")]
    public class SourceList
    {
        public SourceList()
        {
            OrganisationSources = new HashSet<OrganisationSource>();
        }

        [Key]
        public Int64 SourceID { get; set; } 
        public string SourceName { get; set; }
        public string SourceDescription { get; set; }
        public int SourceOrgID { get; set; }
        public bool Internal { get; set; }
        public bool AutoRun { get; set; }
        public int OrderMethod { get; set; }
        public string ImportScript { get; set; }
        public string HelpURL { get; set; }
        public string ShowStockType { get; set; }
        public string SourceApproval { get; set; }
        public bool IsSpecial { get; set; }

        public virtual ICollection<OrganisationSource> OrganisationSources { get; set; }       

    }
}
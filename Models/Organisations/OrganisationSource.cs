using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{

    [Table("OrganisationSource")]
    public class OrganisationSource
    {
        public OrganisationSource()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public Int64 OrgSourceID { get; set; } 
        public Int64 OrgID { get; set; }
        public Int64 SourceID { get; set; }
        public bool SetOutputMe { get; set; }
        public int DefaultMarkup1 { get; set; }
        public int DefaultMarkup2 { get; set; }
        public int DefaultMarkup3 { get; set; }
        public int DefaultMarkup4 { get; set; }
        public int DefaultMarkup5 { get; set; }
        public int DefaultMarkup6 { get; set; } 
        [DataType(DataType.Text), MaxLength(255)]
        public string UsualAvailability { get; set; }
        public int DefaultWarranty { get; set; }
        [DataType(DataType.Text), MaxLength(100)]
        public string OrderFromName { get; set; }
        [DataType(DataType.Text), MaxLength(100)]
        public string OrderFromEMail { get; set; }
        [DataType(DataType.Text), MaxLength(50)]
        public string SourceAccNo { get; set; }
        public Int64 DefaultBranch { get; set; }
        [DataType(DataType.Text), MaxLength(400)]
        public string ExcludeGroups { get; set; }
        public Int64 CollectionID { get; set; }
        public double Price { get; set; }

        public virtual Organisation Organisation { get; set; }
        public virtual SourceList Source { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}

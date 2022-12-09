using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("Couriers")]
    public partial class Couriers
    {
        public Couriers()
        {    
        }
        
        [Key]
        public int CourierID { get; set; }
        public string Courier { get; set; }
        //public virtual ICollection<OrganisationSetting> OrganisationSettings { get; set; }
    }
}
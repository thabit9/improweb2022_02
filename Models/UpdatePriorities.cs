using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("UpdatePriorities")]
    public class UpdatePriority
    {
        public UpdatePriority()
        {           
        }
        public int UpdatePriorityID { get; set; }
        public string UpdatePriorityName { get; set; }

        //public virtual OrganisationSetting OrganisationSettings { get; set;}
        public virtual Organisation Organisation { get; set;}

    }
}
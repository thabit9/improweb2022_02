using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("BankAccountType")]
    public class BankAccountTypex
    {
        public BankAccountTypex()
        {
            Settings = new HashSet<OrganisationSetting>();
        }

        [Key]
        public Int16 BankAccountTypeId { get; set; }
        //[Required]
        public string Description { get; set; }   

        public virtual ICollection<OrganisationSetting> Settings { get; set; }     
    }
}
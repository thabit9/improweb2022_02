using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("AccountCreditType")]
    public class AccountCreditType
    {
        public AccountCreditType()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        public Int16 ccountCreditTypeId { get; set; }
        public string Description { get; set; }

        [InverseProperty(nameof(Account.CreditType))]
        public virtual ICollection<Account> Accounts { get; set; } 
    }
}
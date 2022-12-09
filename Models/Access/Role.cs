using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using improweb2022_02.Models;

namespace improweb2022_02.Models
{
    [Table("Role")]
    public class Role
    {
        public Role()
        {
            RoleAccounts = new HashSet<RoleAccount>();
        } 
        
        [Key]
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public virtual ICollection<RoleAccount> RoleAccounts { get; set; }       
    }
}
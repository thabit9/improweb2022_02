using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using improweb2022_02.Models;

namespace improweb2022_02.Models
{
    [Table("RoleAccount")]
    public class RoleAccount
    {
        //[Key]
        public Int64 RoleId { get; set; }
        //[Key]
        public Int64 UserId { get; set; }
        public bool? Status { get; set; }        

        [ForeignKey(nameof(UserId))]
        public virtual Users Users { get; set; }   
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }                                                                                                                                                                                                                                                                                                                                                                                                                   
    }
}
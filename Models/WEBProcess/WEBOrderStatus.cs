using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("WEBOrderStatus")]
    public class WEBOrderStatus 
    {
        public WEBOrderStatus()
        {       
        }

        [Key]
        public int StatusID { get; set; }
        public string Status { get; set; }

    }
}
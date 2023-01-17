using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace improweb2022_02.Models
{
    [Table("GlobalSettings")]
    public class GlobalSettings
    {   
        public GlobalSettings()
        {
        }

        //[Key]
        public string GlobalKey { get; set; }
        public string GlobalValue { get; set; }
    }
}
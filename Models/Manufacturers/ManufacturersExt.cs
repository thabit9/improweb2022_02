using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using improweb2022_02.Models;

namespace improweb2022_02.Models
{
    [Table("ManufacturersExt")]
    public class ManufacturersExt
    {
        public ManufacturersExt()
        {
        }
        [Key]
        public Int64 ManufacturerExtID { get; set; }
        public string Manufaturer { get; set; }
        public Int64 ManufID { get; set; }
        public virtual Manufacturer Manufacturerx { get; set; }
    }
}